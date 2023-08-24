using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Dynamic
{
    [Serializable]
    public class DynamicListingChild : BaseContainer
    {
        [JsonProperty("data")]
        public dynamic Data { get; set; }
    }
}
