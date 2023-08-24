namespace RedTrack.Services.Handlers
{
    public interface IApiRequestHandler
    {
        Task<string> GetAsync(string path);

    }
}