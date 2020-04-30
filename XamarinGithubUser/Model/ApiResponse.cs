﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace XamarinGithubUser.Model
{
    public class ApiResponse
    {
        public ApiResponse()
        {

        }
        [JsonProperty(PropertyName = "total_count")]
        public string totalCount { get; set; }

        [JsonProperty(PropertyName = "incomplete_results")]
        public string incompleteResults { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<User> items { get; set; }

        public override string ToString()
        {
            return totalCount;
        }
    }
}
