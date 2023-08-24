using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Post
{
    [Serializable]
    public class PostContainer : BaseContainer
    {
        [JsonProperty("data")]
        public PostData Data { get; set; }
    }
}
