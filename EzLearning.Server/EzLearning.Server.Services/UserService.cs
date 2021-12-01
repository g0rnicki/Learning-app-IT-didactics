using EzLearning.Server.Dal;
using EzLearning.Server.Services.Contracts;
using EzLearning.Server.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EzLearning.Server.Services
{
    public class UserService : IUserService
    {
        private readonly string _tokenSecret;
        private readonly AppDataContext _ctx;

        public UserService(AppDataContext ctx, string tokenSecret)
        {
            _tokenSecret = tokenSecret;
            _ctx = ctx;
        }

        public Task<AuthorizationResult> AuthorizeUserAsync(string username, string password)
        {
            var queriedUser = (from u in _ctx.users
                         where u.Username == username
                         select u).FirstOrDefault();

            var passwordHash = GetPasswordHash(password);

            if (queriedUser == null || !queriedUser.PasswordHash.Equals(passwordHash))
            {
                return Task.FromResult(new AuthorizationResult { IsSuccessfull = false, Token = string.Empty });
            }
            else
            {
                return Task.FromResult(new AuthorizationResult { IsSuccessfull = true, Token = GenerateJwtToken(queriedUser) });
            }
        }

        public Task<UserDto> GetUserByIdAsync(Guid userId)
        {
            var queriedUser = (from u in _ctx.users
                               where u.Id == userId
                               select u).FirstOrDefault();
            return Task.FromResult(queriedUser != null ? new UserDto { Id = queriedUser.Id, Username = queriedUser.Username } : null);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(2),        // Valid for 2 hours
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static string GetPasswordHash(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var stringBuilder = new StringBuilder();

            for(var i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
