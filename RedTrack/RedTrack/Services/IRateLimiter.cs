namespace RedTrack.Services
{
    public interface IRateLimiter
    {
        int RemainingRequests { get; }
        int SecondsToReset { get; }
        DateTime TimeToReset { get; }

        Task<bool> CanMakeRequestAsync();
        Task RecordRequestAsync(int remainingRequests);
        void setRateLimiter(int remainingRequests, int resetTime);
    }
}