using Newtonsoft.Json;
using System.ComponentModel;

namespace FetchGitUserDetailsMVCApp.Models
{
    public class RepoDetail
    {
        [JsonProperty("name")]
        [DisplayName("Repository Name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("stargazers_count")]
        [DisplayName("Stargazers Count")]
        public int StargazersCount { get; set; }

        [JsonProperty("html_url")]
        [DisplayName("Repository Link")]
        public string HtmlUrl { get; set; }
    }
}
