using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Post
{
    [Serializable]
    public class PostResultContainer
    {
        [JsonProperty("json")]
        public PostResult JSON { get; set; }
    }
}
