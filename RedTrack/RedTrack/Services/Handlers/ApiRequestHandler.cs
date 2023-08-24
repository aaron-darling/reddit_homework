using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Reddit.Exceptions;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Encodings.Web;
//using HttpClient


namespace RedTrack.Services.Handlers
{
    public class ApiRequestHandler : IApiRequestHandler
    {
        private readonly IRateLimiter _rateLimiter;
        private readonly string _baseUrl;
        private readonly string _baseTokenUrl;
        private string _token;
        private readonly string _appId;
        private readonly string _refreshToken;
        private readonly HttpClient _httpClient;
        private readonly string _deviceId;


        public ApiRequestHandler(IRateLimiter rateLimiter, string appId, string refreshToken, HttpClient? httpClient = null)
        {
            _baseUrl = "https://oauth.reddit.com/r/";
            _baseTokenUrl = "https://www.reddit.com";
            _deviceId = Guid.NewGuid().ToString();
            _appId = appId;
            _refreshToken = refreshToken;

            _httpClient = httpClient == null ? new HttpClient() : httpClient;
            _rateLimiter = rateLimiter;
            SetAccessToken();
        }
        private async void SetAccessToken()
        {

            string endpoint = $"{_baseTokenUrl}/api/v1/access_token";

            HttpContent content = new StringContent("");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, endpoint);
            requestMessage.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(_appId + ":" )));
            requestMessage.Headers.Add("User-Agent", "RedTrack v2.0");
           
            requestMessage.Headers.Add("device_id", _deviceId);

            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("grant_type", "refresh_token"));
            formData.Add(new KeyValuePair<string, string>("refresh_token", _refreshToken));
           
            requestMessage.Content = new FormUrlEncodedContent(formData);
        


        var res = _httpClient.Send(requestMessage);
 

            if (res != null && res.IsSuccessStatusCode)
            {
                var resContent = await res.Content.ReadAsStringAsync();
                _token = JsonConvert.DeserializeObject<JObject>(resContent).GetValue("access_token").ToString();
            }
            else
            {
                throw new RedditUnauthorizedException("Token rejected");
            }
        }

        public async Task<string> GetAsync(string path)
        {

            var rtn = await processGetRequest(path);

            return rtn;


        }
        private async Task<string> processGetRequest(string path)
        {
            if(string.IsNullOrEmpty(_token))
            {
                throw new RedditUnauthorizedException("Token not set");
            }
            while (!await _rateLimiter.CanMakeRequestAsync())
            {
                Thread.Sleep(500);
            }


            string endpoint = $"{_baseUrl}{path}";
            HttpContent content = new StringContent("");
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint);
            requestMessage.Headers.Add("Authorization", "bearer " + _token);
            requestMessage.Headers.Add("User-Agent", "RedTrack v2.0");


            var res = await _httpClient.SendAsync(requestMessage);
            return await ProcessResponse(res);
        }
        private async Task<string> ProcessResponse(HttpResponseMessage res)
        {

            if (res == null)
            {
                throw new Exception("Reddit API returned null response.");
            }
            else if (!res.IsSuccessStatusCode)
            {
                switch (res.StatusCode)
                {
                    default:
                        throw new Exception("Reddit API returned non-success (" + res.StatusCode.ToString() + ") response.");
                    case 0:
                        throw new Exception("Reddit API failed to return a response.");
                    case HttpStatusCode.BadRequest:
                        throw new RedditBadRequestException("Reddit API returned Bad Request (400) response.");
                    case HttpStatusCode.Unauthorized:
                        throw new RedditUnauthorizedException("Reddit API returned Unauthorized (401) response.");
                    case HttpStatusCode.Forbidden:
                        throw new RedditForbiddenException("Reddit API returned Forbidden (403) response.");
                    case HttpStatusCode.BadGateway:
                        throw new RedditBadGatewayException("Reddit API returned Bad Gateway (502) response.");
                    case HttpStatusCode.GatewayTimeout:
                        throw new RedditGatewayTimeoutException("Reddit API returned Gateway Timeout (504) response.");
                }
            }
            else
            {
                var headers = res.Headers;
                var rateLimit = headers.GetValues("x-ratelimit-remaining").FirstOrDefault();
                var secondsToReset = headers.GetValues("x-ratelimit-reset").FirstOrDefault();
                _rateLimiter.setRateLimiter(!string.IsNullOrEmpty(rateLimit) ?(int)decimal.Parse(rateLimit) : _rateLimiter.RemainingRequests,
                    !string.IsNullOrEmpty(secondsToReset) ? (int)decimal.Parse(secondsToReset) : _rateLimiter.SecondsToReset);

                return await res.Content.ReadAsStringAsync();
            }
        }
    }
}
