using FetchGitUserDetailsMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FetchGitUserDetailsMVCApp.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string username)
        {
            UserDetail userDetail = new UserDetail();

            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("User-Agent", "FetchGitUserDetailsMVCApp");
                var response = await client.GetAsync($"https://api.github.com/users/{username}");


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    userDetail = JsonConvert.DeserializeObject<UserDetail>(content);

                    response = await client.GetAsync(userDetail.RepoUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        content = await response.Content.ReadAsStringAsync();
                        List<RepoDetail> repoDetails = JsonConvert.DeserializeObject<List<RepoDetail>>(content);
                        userDetail.RepoDetails = repoDetails.OrderByDescending(r => r.StargazersCount).Take(5).ToList();
                    }
                }
                else
                    throw new ApplicationException("Error has occured.");
            }
            catch (Exception ex)
            {
                userDetail.IsError = true;
                userDetail.ErrorMessage = "Error:" + ex.Message;
            }

            return View("Index", userDetail);
        }
    }
}
