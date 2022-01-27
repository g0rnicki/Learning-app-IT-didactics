using System.Threading.Tasks;
using Test_app_1.Services.Interfaces.Contracts;

namespace Test_app_1.Services.Interfaces
{
    public interface IRestClient
    {
        Task<LoginResult> AuthorizeUser(string username, string password);
        Task<RegisterResult> RegisterUser(string username, string email, string password);
        void Logout();
        bool IsLoggedIn();
    }
}
