using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private string _username = string.Empty;
        
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
                _username = username;
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
                _username = string.Empty;
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

        public async Task<List<ChapterDto>> GetAllChapters()
        {
            var result = new List<ChapterDto>();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{serverAddress}/api/learning/chapter");
            var response = await _authorizedHttpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                var chapters = JsonConvert.DeserializeObject<ChapterDto[]>(await response.Content.ReadAsStringAsync());
                result.AddRange(chapters);
            }

            return result;
        }

        public async Task<List<LessonDto>> GetLessonsByChapterId(int chapterId)
        {
            var result = new List<LessonDto>();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{serverAddress}/api/learning/chapter/{chapterId}/lessons");
            var response = await _authorizedHttpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                var lessons = JsonConvert.DeserializeObject<LessonDto[]>(await response.Content.ReadAsStringAsync());
                result.AddRange(lessons);
            }

            return result;
        }

        public async Task<LessonDto> GetLessonById(int lessonId)
        {
            LessonDto result = null;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{serverAddress}/api/learning/lesson/{lessonId}");
            var response = await _authorizedHttpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<LessonDto>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        public async Task<QuestionDto> GetQuestionById(int questionId)
        {
            QuestionDto result = null;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{serverAddress}/api/learning/question/{questionId}");
            var response = await _authorizedHttpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<QuestionDto>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        public async Task<int?> GetLessonIdByLessonNumberAndPart(int lessonNumber, int part)
        {
            int? result = null;
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{serverAddress}/api/learning/lesson/{lessonNumber}/{part}");
            var response = await _authorizedHttpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

        public async Task<List<QuestionDto>> GetChapterQuizQuestionsByChapterId(int chapterId)
        {
            var result = new List<QuestionDto>();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{serverAddress}/api/learning/chapter/{chapterId}/questions");
            var response = await _authorizedHttpClient.SendAsync(httpRequest);

            if (response.IsSuccessStatusCode)
            {
                var questions = JsonConvert.DeserializeObject<QuestionDto[]>(await response.Content.ReadAsStringAsync());
                result.AddRange(questions);
            }

            return result;
        }

        public string GetCurrentUsername()
        {
            return _username;
        }

        public Task SaveUserProgress(UserFinishedLessonDto progress)
        {
            throw new NotImplementedException();
        }
    }
}
