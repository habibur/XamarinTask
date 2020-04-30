using System;
using System.Threading.Tasks;
using Refit;
using XamarinGithubUser.Model;

namespace XamarinGithubUser.Interface
{
    [Headers("User-Agent: :request:")]
    public interface IGitHubApi
    {
        [Get("/search/users?q=location:germany")]
        Task<ApiResponse> GetUser();
        //[Get("/users/{user}")]
        //Task<ApiResponse> GetUser(string user);
        //[Get("/users/{user}")]
        //Task<User> GetUser(string user);
        //[Get("/users/{user}/repos")]
        //Task<User> GetRepo(string repo);

        [Get("/users/mathiasbynens/repos")]
        Task<UserRepo> GetOwner();
    }
}
