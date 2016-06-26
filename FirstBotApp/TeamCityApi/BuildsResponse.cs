using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamCityApi
{
    public class BuildsResponse
    {
        [JsonProperty("build")]
        public List<Build> Builds { get; set; } 
    }
}