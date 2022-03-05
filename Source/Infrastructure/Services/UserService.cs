using Microsoft.Extensions.Configuration;
using RestSharp;
using Tawasal.ViewModels;
using Application.Interfaces;
using Application.Models;

namespace Tawasal.Data
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        private const string baseApiUrl = "https://dummyapi.io/data/v1/";
        public async Task<UsersData> GetUsersAsync(int limit = 10)
        {
            var client = new RestClient(baseApiUrl + "user?limit=" + limit);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("app-id", _configuration["AppSettings:AppId"]);
            IRestResponse response = await client.ExecuteAsync(request);

            var data = System.Text.Json.JsonSerializer.Deserialize<UsersData>(response.Content);
            return data;
        }

        public async Task<UserPosts> GetUserPostsAsync(string userId, int limit = 10)
        {
            var client = new RestClient(baseApiUrl + $"user/{userId}/post?limit={limit}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("app-id", _configuration["AppSettings:AppId"]);
            IRestResponse response = await client.ExecuteAsync(request);

            var data = System.Text.Json.JsonSerializer.Deserialize<UserPosts>(response.Content);
            data.GotAt = DateTime.Now;
            return data;
        }
    }
}
