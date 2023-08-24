using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Post
{
    [Serializable]
    public class PostChild : BaseContainer
    {
        [JsonProperty("data")]
        public Post Data { get; set; }
    }
}
