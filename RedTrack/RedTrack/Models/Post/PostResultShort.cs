using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Post
{
    [Serializable]
    public class PostResultShort : BaseResult
    {
        [JsonProperty("data")]
        public PostResultShortData Data { get; set; }
    }
}
