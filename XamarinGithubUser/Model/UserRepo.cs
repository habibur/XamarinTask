using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace XamarinGithubUser.Model
{
    public class UserRepo
    {
        public UserRepo()
        {
        }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("node_id")]
        public string node_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("full_name")]
        public string full_name { get; set; }

        public List<Owner> items { get; set; }

        public override string ToString()
        {
            return name;
        }

    }

}

