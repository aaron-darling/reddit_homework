using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Post
{
    [Serializable]
    public class PostResult : BaseResult
    {
        [JsonProperty("data")]
        public PostResultData Data { get; set; }
    }
}
