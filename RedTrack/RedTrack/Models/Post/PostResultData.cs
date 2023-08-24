using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RedTrack.Models.Post
{
    [Serializable]
    public class PostResultData
    {
        [JsonProperty("things")]
        public List<PostChild> Things { get; set; }
    }
}
