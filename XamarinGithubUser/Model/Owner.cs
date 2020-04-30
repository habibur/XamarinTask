using System;
using Newtonsoft.Json;

namespace XamarinGithubUser.Model
{
    public class Owner
    {
        public Owner()
        {
        }
        [JsonProperty("login")]
        //public string login { get; set; }
        public string userName { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("node_id")]
        public string node_id { get; set; }

        [JsonProperty("avatar_url")]
        public string avatar_url { get; set; }

        [JsonProperty("gravatar_id")]
        public string gravatar_id { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("html_url")]
        public string html_url { get; set; }

        [JsonProperty("followers_url")]
        public string followers_url { get; set; }

        [JsonProperty("following_url")]
        public string following_url { get; set; }

        [JsonProperty("gists_url")]
        public string gists_url { get; set; }

        [JsonProperty("starred_url")]
        public string starred_url { get; set; }

        [JsonProperty("subscriptions_url")]
        public string subscriptions_url { get; set; }

        [JsonProperty("organizations_url")]
        public string organizations_url { get; set; }

        [JsonProperty("repos_url")]
        public string repos_url { get; set; }

        [JsonProperty("events_url")]
        public string events_url { get; set; }

        [JsonProperty("received_events_url")]
        public string received_events_url { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("site_admin")]
        public bool site_admin { get; set; }

        public override string ToString()
        {
            //var avatar = new UriImageSource{ new Uri(avatar_url)};

            return userName;
            //return "Name: " + userName + System.Environment.NewLine + "Avatar: " + avatar_url + System.Environment.NewLine + " Repos: " + repos_url;
        }

    }
}
