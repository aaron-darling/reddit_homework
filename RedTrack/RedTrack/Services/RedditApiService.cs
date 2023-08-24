using Newtonsoft.Json;
using RedTrack.Models;
using RedTrack.Models.Dynamic;
using RedTrack.Models.Post;
using RedTrack.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTrack.Services
{
    public class RedditApiService : IRedditApiService
    {
        private readonly IApiRequestHandler _apiRequestHandler;

        public RedditApiService(IApiRequestHandler apiRequestHandler)
        {
            _apiRequestHandler = apiRequestHandler;
        }

        public async Task<List<Post>> GetPostsAsync(string subreddit, Dictionary<string, string> parameters)
        {
            string queryString = string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            string endpoint = $"{subreddit}/top?{queryString}";
            string responseJson = await _apiRequestHandler.GetAsync(endpoint);
            List<Post> posts = new List<Post>();
            DynamicListingContainer res = JsonConvert.DeserializeObject<DynamicListingContainer>(responseJson);
            foreach (DynamicListingChild child in res.Data.Children)
            {
                switch (child.Kind)
                {
                    case "t3":
                        posts.Add(JsonConvert.DeserializeObject<Post>(JsonConvert.SerializeObject(child.Data)));
                        break;
                }
            }
            return posts;
        }
    }

}
