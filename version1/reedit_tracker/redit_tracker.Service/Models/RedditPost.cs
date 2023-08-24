
using Reddit.Things;


namespace reddit_tracker.Service.Models
{
    public class RedditPost
    {       
        public string Subreddit { get; set; }
        public string Title { get; set; }
        public int Downs { get; set; }
        public int Ups { get; set; }
        public string AuthorFullname { get; set; }
        public int NumComments { get; set; }
        public string Id { get; set; }
        public string Author { get; set; }
        public DateTime CreatedUTC { get; set; }

        public RedditPost() { }
        public RedditPost(Reddit.Controllers.Post post)
        {
            
            Id = post.Id;
            Subreddit = post.Subreddit;
            Title = post.Title;
            Downs = post.DownVotes;
            Ups = post.UpVotes;
            AuthorFullname = post.Fullname;
            Author = post.Author;
            //NumComments = post.Comments.GetComments().Count();
          
        }
        public RedditPost(string subreddit
                    , string title
                    , int downs
                    , int ups
                    , string authorFullname
                    , int numComments
                    , string id
                    , string author
                    , DateTime createdUTC)
        {
            Subreddit = subreddit;
            Title = title;
            Downs = downs;
            Ups = ups;
            AuthorFullname = authorFullname;
            NumComments = numComments;
            Id = id;
            Author = author;
            CreatedUTC = createdUTC;
        }
        public RedditPost(Post post)
        {
            Subreddit = post.Subreddit;
            Title = post.Title;
            Downs = post.Downs;
            Ups = post.Ups;
            AuthorFullname = post.AuthorFullname;
            NumComments = post.NumComments;
            Id = post.Id;
            Author = post.Author;
            CreatedUTC = post.CreatedUTC;
        }
    }
}
