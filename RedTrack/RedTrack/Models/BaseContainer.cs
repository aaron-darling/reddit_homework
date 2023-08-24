using Newtonsoft.Json;
using System;

namespace RedTrack.Models
{
    [Serializable]
    public abstract class BaseContainer
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
    }
}
