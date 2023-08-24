using Newtonsoft.Json;
using System;

namespace RedTrack.Models.Dynamic
{
    [Serializable]
    public class DynamicShortListingContainer : BaseContainer
    {
        [JsonProperty("data")]
        public DynamicShortListingData Data { get; set; }
    }
}
