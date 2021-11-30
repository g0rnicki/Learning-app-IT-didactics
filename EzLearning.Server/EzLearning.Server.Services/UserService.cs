using EzLearning.Server.Services.Contracts;
using EzLearning.Server.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EzLearning.Server.Services
{
    public class UserService : IUserService
    {
        private readonly string _tokenSecret;

        public UserService(string tokenSecret)
        {
            _tokenSecret = tokenSecret;
        }

        public Task<AuthorizationResult> AuthorizeUserAsync(string username, string password)
        {
            var user = new User { Id = 42 };
            var result = new AuthorizationResult { IsSuccessfull = true, Token = GenerateJwtToken(user) };
            return Task.FromResult(result);
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            return Task.FromResult(new User { Id = 42 });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(5),        // Valid for 5 minutes
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
