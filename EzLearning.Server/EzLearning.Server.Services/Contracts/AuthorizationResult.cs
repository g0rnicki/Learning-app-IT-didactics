namespace EzLearning.Server.Services.Contracts
{
    public class AuthorizationResult
    {
        public bool IsSuccessfull { get; set; }
        public string Token { get; set; }
    }
}
