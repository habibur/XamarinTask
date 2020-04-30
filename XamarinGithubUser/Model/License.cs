using System;
using Newtonsoft.Json;

namespace XamarinGithubUser.Model
{
    public class License
    {
        public License()
        {
        }

        [JsonProperty("key")]
        public string key { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("spdx_id")]
        public string spdx_id { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("node_id")]
        public string node_id { get; set; }
    }
}
