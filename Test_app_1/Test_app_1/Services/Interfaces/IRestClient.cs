using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_app_1.Services.Interfaces.Contracts;

namespace Test_app_1.Services.Interfaces
{
    public interface IRestClient
    {
        Task<LoginResult> AuthorizeUser(string username, string password);
        Task<RegisterResult> RegisterUser(string username, string email, string password);
        Task<List<ChapterDto>> GetAllChapters();
        Task<List<LessonDto>> GetLessonsByChapterId(int chapterId);
        Task<LessonDto> GetLessonById(int lessonId);
        Task<int?> GetLessonIdByLessonNumberAndPart(int lessonNumber, int part);
        Task<QuestionDto> GetQuestionById(int questionId);
        Task<List<QuestionDto>> GetChapterQuizQuestionsByChapterId(int chapterId);
        Task SaveUserProgress(UserFinishedLessonDto progress);
        Task<int?> GetTotalLessonsFinished(Guid userId);
        Task<List<int>> GetLessonNumbersForFinishedChapterLesssons(Guid userId, int chapterId);
        void Logout();
        bool IsLoggedIn();
        string GetCurrentUsername();
        Guid GetCurrentUserId();
    }
}
