using System.Threading.Tasks;
using Test_app_1.Services.Interfaces;
using Test_app_1.Services.Interfaces.Contracts;

namespace Test_app_1.Services
{
    public class RestClient : IRestClient
    {
        public Task<LoginResult> AuthorizeUser(string username, string password)
        {
            return Task.FromResult(new LoginResult { IsSuccessfull = true, Token = "howdy" });
        }
    }
}
