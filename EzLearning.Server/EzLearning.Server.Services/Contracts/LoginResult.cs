using System;

namespace EzLearning.Server.Services.Contracts
{
    public class LoginResult
    {
        public bool IsSuccessfull { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }
    }
}
