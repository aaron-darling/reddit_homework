using Reddit.Exceptions;
using RedTrack.Models.Post;


namespace RedTrack.Services.Moniters
{
    public class PostAnalyticsMonitor : IAnalyticsMonitor
    {
        private readonly IRedditApiService _apiService;
        private readonly string _subreddit;
        private Timer _timer;
        private bool _isMonitoring;
        private DateTime _lastUpdate;
        public bool IsMonitoring { get { return _isMonitoring; } }
        public DateTime LastUpdated { get; set; }
        public Post MostUpVotes { get; set; }
        public string MostPostsAuthor { get; set; }
        public int MostPostsNumber { get; set; }

        public PostAnalyticsMonitor(IRedditApiService apiService, string subreddit)
        {
            _apiService = apiService;
            _subreddit = subreddit;

        }

        public void StartMonitoring(string after = "", string before = "", int limit = 100, int count = 0)
        {
            _isMonitoring = true;
            _timer = new Timer(async state => await CheckForNewPostsAsync(after, before, limit, count), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        public void StopMonitoring()
        {
            _isMonitoring = false;
            _timer.Dispose();
        }

        private async Task CheckForNewPostsAsync(string after = "", string before = "", int limit = 100, int count = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "after", after },
                { "before", before },
                { "limit", limit.ToString() },
                { "count", count.ToString() },
                { "t", "all" },
                { "show", "all" },
                { "sr_detail", "False"},
                { "raw_json", "1" }
             };


            List<Post> posts = await _apiService.GetPostsAsync(_subreddit, parameters);

            try
            {
                if (posts is null || posts.Count < 1)
                    return;

                var mostPosts = posts.GroupBy(c => c.Author)
                                          .OrderByDescending(g => g.Count())
                                          .Select(g => new { Name = g.Key, Count = g.Count() })
                                          .FirstOrDefault();

                MostPostsAuthor = mostPosts.Name;
                MostPostsNumber = mostPosts.Count;

                MostUpVotes = posts.MaxBy(x => x.Ups);

                LastUpdated = DateTime.Now;

            }
            catch (RedditBadGatewayException)
            {
                //ignore, these errors are reddit's fault
            }
            catch (RedditGatewayTimeoutException)
            {
                //ignore, these errors are reddit's fault
            }

        }
    }

}
