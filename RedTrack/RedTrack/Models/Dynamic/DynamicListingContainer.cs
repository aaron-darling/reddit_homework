using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Dynamic
{
    [Serializable]
    public class DynamicListingContainer : BaseContainer
    {
        [JsonProperty("data")]
        public DynamicListingData Data { get; set; }
    }
}
