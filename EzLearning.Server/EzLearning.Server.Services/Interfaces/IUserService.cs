using EzLearning.Server.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace EzLearning.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResult> LoginUserAsync(string username, string password);
        Task<UserDto> GetUserByIdAsync(Guid userId);
    }
}
