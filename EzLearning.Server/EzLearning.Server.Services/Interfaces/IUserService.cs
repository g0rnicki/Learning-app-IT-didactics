using EzLearning.Server.Services.Contracts;
using System.Threading.Tasks;

namespace EzLearning.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthorizationResult> AuthorizeUserAsync(string username, string password);
        Task<User> GetUserByIdAsync(int userId);
    }
}
