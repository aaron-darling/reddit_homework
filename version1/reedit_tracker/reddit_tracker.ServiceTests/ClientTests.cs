using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reddit;

namespace reddit_tracker.Service.Tests
{
    [TestClass()]
    public class ClientTests
    {
        private RedditClient _redditClient;
        private Reddit.Controllers.Subreddit _subreddit;
        private SubredditClient _subClient;
        private Reddit.Controllers.SubredditPosts _subredditPost;
        private List<Reddit.Controllers.Post> _redditPosts;
        private string _subRedditName;
        private Reddit.Controllers.Dispatch _dispatch;

        [TestInitialize]
        public void TestInitialize()
        {
            _subRedditName = "redditerName";
     
            _redditPosts = new List<Reddit.Controllers.Post>();
            _dispatch = new Reddit.Controllers.Dispatch("", "", "", "", new RestSharp.RestClient());

            _redditPosts.Add(new Reddit.Controllers.Post(_dispatch,  _subRedditName, title: "Post1",fullname:"test1", author: "Author1", id: "1", upVotes: 2, downVotes: 3));
            _redditPosts.Add(new Reddit.Controllers.Post(_dispatch, _subRedditName, title: "Post2", fullname:"test1", author: "Author1", id: "2", upVotes: 4, downVotes: 1));
            _redditPosts.Add(new Reddit.Controllers.Post(_dispatch, _subRedditName, title: "Post3", fullname:"test2", author: "Author2", id: "3", upVotes: 1, downVotes: 1));

            _subredditPost = new Reddit.Controllers.SubredditPosts(_dispatch, _subRedditName,top: _redditPosts);
            _subreddit = new Reddit.Controllers.Subreddit(_dispatch, _subRedditName);
            _subreddit.Posts = _subredditPost;

            _subClient = new SubredditClient(_subreddit);
            
        }


        [TestMethod]
        public void TestStartMonitoring()
        {
            _subClient.StartMonitoring();
            
            Assert.IsTrue(_subClient.IsMonitoring);
        }


        [TestMethod]
        public void TestStopMonitoring()
        {
            _subClient.StartMonitoring();
            _subClient.StopMonitoring();

            Assert.IsFalse(_subClient.IsMonitoring);
        }

        [TestMethod]
        public void TestLoadMostPostsCorrectMostUpPostId()
        {
            
            _subClient.LoadMostPosts (_redditPosts);

            Assert.AreEqual("2", _subClient.MostUpPost.Id);
        }

        [TestMethod]
        public void TestLoadMostPostsCorrectMostUpPostAuthor()
        {

            _subClient.LoadMostPosts(_redditPosts);

            
            Assert.AreEqual("Author1", _subClient.MostUpPost.Author);
            
        }

        [TestMethod]
        public void TestLoadMostPostsCorrectMostUpPostTitle()
        {

            _subClient.LoadMostPosts(_redditPosts);

            Assert.AreEqual("Post2", _subClient.MostUpPost.Title);
         

        }

        [TestMethod]
        public void TestLoadMostPostsCorrectMostUpPostUps()
        {

            _subClient.LoadMostPosts(_redditPosts);

            Assert.AreEqual(4, _subClient.MostUpPost.Ups);

         
        }

        [TestMethod]
        public void TestLoadMostPostsCorrectMostDownPostId()
        {

            _subClient.LoadMostPosts(_redditPosts);

            Assert.AreEqual("1", _subClient.MostDownPost.Id);
        }


        [TestMethod]
        public void TestLoadMostPostsCorrectMostDownPostAuthor()
        {

            _subClient.LoadMostPosts(_redditPosts);
            Assert.AreEqual("Author1", _subClient.MostDownPost.Author);
            
        }

        [TestMethod]
        public void TestLoadMostPostsCorrectMostDownPostTitle()
        {

            _subClient.LoadMostPosts(_redditPosts);

            Assert.AreEqual("Post1", _subClient.MostDownPost.Title);
            
        }


        [TestMethod]
        public void TestSubredditClientsContrtructor()
        {
            
            var TestClient = new SubredditClient(_subreddit);
            TestClient.StartMonitoring();

            Assert.IsNotNull(TestClient.MostUpPost);

        }

        [TestMethod]
        public void TestLoadMostPostsCorrectMostPostAuthor()
        {

            _subClient.LoadMostPosts(_redditPosts);

            Assert.AreEqual("Author1", _subClient.MostPostsAuthor);



        }

        [TestMethod]
        public void TestLoadMostPostsCorrectMostPostNum()
        {

            _subClient.LoadMostPosts(_redditPosts);

            Assert.AreEqual(2, _subClient.MostPostsNum);

        }

        
    }
}