using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_app_1.Services.Interfaces;
using Test_app_1.Services.Interfaces.Contracts;

namespace Test_app_1.Services
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _genericHttpClient;
        private HttpClient _authorizedHttpClient = null;

        private static readonly string serverAddress = "http://10.0.2.2:4040";

        public RestClient()
        {
            _genericHttpClient = new HttpClient();
        }

        public async Task<LoginResult> AuthorizeUser(string username, string password)
        {
            var requestBody = new AuthorizationRequestBody { Username = username, Password = password };
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{serverAddress}/api/users/login")
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
            };
            var response = await _genericHttpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                var result =  JsonConvert.DeserializeObject<LoginResult>(await response.Content.ReadAsStringAsync());
                SetAuthorizedUser(result.Token);
                return result;
            }
            else
            { 
                return new LoginResult { IsSuccessfull = false, Token = "" };
            }
        }

        public async Task<RegisterResult> RegisterUser(string username, string email, string password)
        {
            var requestBody = new RegisterUserRequestBody
            {
                Username = username,
                Email = email,
                Password = password
            };
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{serverAddress}/api/users/register")
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
            };
            var response = await _genericHttpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<RegisterResult>(await response.Content.ReadAsStringAsync());
                return result;
            }
            else
            {
                return new RegisterResult { IsSuccessfull = false, Message = "Ups... Something went wrong at the server." };
            }
        }



        public void Logout()
        {
            if (_authorizedHttpClient != null)
            {
                _authorizedHttpClient.Dispose();
                _authorizedHttpClient = null;
            }
        }

        public bool IsLoggedIn()
        {
            return _authorizedHttpClient != null;
        }

        private void SetAuthorizedUser(string token)
        {
            if (_authorizedHttpClient != null)
            {
                Logout();
            }

            _authorizedHttpClient = new HttpClient
            {
                BaseAddress = new Uri(serverAddress)
            };

            _authorizedHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }
    }
}
