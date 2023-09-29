using Newtonsoft.Json;

namespace FetchGitUserDetailsMVCApp.Models
{
    public class UserDetail
    {
        [JsonProperty("login")]
        public string UserName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("repos_url")]
        public string RepoUrl { get; set; }

        public List<RepoDetail> RepoDetails { get; set; }


        //We can create new ErrorHadling class for below fields, But for simplicity I have included in this
        public bool IsError { get; set; }

        public string ErrorMessage { get; set; }
    }
}
