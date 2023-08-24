using RedTrack.Models.Post;

namespace RedTrack.Services.Moniters
{
    public interface IAnalyticsMonitor
    {
        bool IsMonitoring { get; }
        DateTime LastUpdated { get; set; }
        Post MostDownVotes { get; set; }
        string MostPostsAuthor { get; set; }
        int MostPostsNumber { get; set; }
        Post MostUpVotes { get; set; }

        void StartMonitoring(string after = "", string before = "", int limit = 100, int count = 0);
        void StopMonitoring();
    }
}