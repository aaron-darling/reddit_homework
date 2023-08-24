using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Post
{
    [Serializable]
    public class PostResultShortContainer
    {
        [JsonProperty("json")]
        public PostResultShort JSON { get; set; }
    }
}
