using RedTrack.Models.Post;

namespace RedTrack.Services
{
    public interface IRedditApiService
    {
        Task<List<Post>> GetPostsAsync(string subreddit, Dictionary<string, string> parameters);
    }
}