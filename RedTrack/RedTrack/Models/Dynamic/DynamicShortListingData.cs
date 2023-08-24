using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RedTrack.Models.Dynamic
{
    [Serializable]
    public class DynamicShortListingData : BaseData
    {
        [JsonProperty("children")]
        public List<dynamic> Children { get; set; }
    }
}
