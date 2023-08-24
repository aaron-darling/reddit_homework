namespace reddit_tracker.Service
{
    using Reddit;
    using Reddit.Controllers.EventArgs;
    using Reddit.Exceptions;
    using Reddit.Things;
    using reddit_tracker.Service.Models;


    public class SubredditClient 
    {
        private Reddit.Controllers.Subreddit _subreddit;
        public DateTime LastUpdate { get; private set; }
        public RedditPost MostDownPost { get; private set; }
        public RedditPost MostUpPost { get; private set; }

        public string MostPostsAuthor { get; set; }
        public int MostPostsNum { get; set; }

        public bool IsMonitoring { get; private set; }


        public SubredditClient(Reddit.Controllers.Subreddit subreddit)
        {

            _subreddit = subreddit;

        }
      
        public async void StopMonitoring()
        {
            IsMonitoring = false;
            await _subreddit.Posts.MonitorNew();
            _subreddit.Posts.NewUpdated -= C_PostsUpdated;
        }


        public async void StartMonitoring()
        {
            var NewPosts = new List<Post>();
            IsMonitoring = true;
            MostUpPost = new RedditPost();
            MostDownPost = new RedditPost();

            LoadMostPosts(await _subreddit.Posts.GetTopAsync());

          
            await _subreddit.Posts.MonitorNew(breakOnFailure: false);
            _subreddit.Posts.NewUpdated += C_PostsUpdated;

        }

        public void LoadMostPosts(List<Reddit.Controllers.Post> posts)
        {
            try
            {
                if (posts is null || posts.Count < 1)
                    return;

                var mostPosts = posts.GroupBy(c => c.Author)
                                          .OrderByDescending(g => g.Count())
                                          .Select(g => new { Name = g.Key, Count = g.Count() })
                                          .FirstOrDefault();

                MostPostsAuthor = mostPosts.Name;
                MostPostsNum = mostPosts.Count;

                RedditPost NewUpMost = new RedditPost(posts.MaxBy(x => x.UpVotes));
                RedditPost NewDownMost = new RedditPost(posts.MaxBy(x => x.DownVotes));


                if (MostUpPost is null || MostUpPost.Ups < NewUpMost.Ups || MostUpPost.Id == NewUpMost.Id)
                    MostUpPost = NewUpMost;
                if (MostDownPost is null || MostDownPost.Downs < NewDownMost.Downs || MostDownPost.Id == NewDownMost.Id)
                    MostDownPost = NewDownMost;

                LastUpdate = DateTime.Now;
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
        private async void C_PostsUpdated(object sender, PostsUpdateEventArgs e)
        {
            try
            {
                LoadMostPosts(await _subreddit.Posts.GetTopAsync());

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


