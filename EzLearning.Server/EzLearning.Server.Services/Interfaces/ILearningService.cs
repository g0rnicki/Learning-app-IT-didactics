using EzLearning.Server.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EzLearning.Server.Services.Interfaces
{
    public interface ILearningService
    {
        Task<List<ChapterDto>> GetAllChapters();
        Task<List<LessonDto>> GetLessonsByChapterId(int chapterId);
        Task<LessonDto> GetLessonById(int lessonId);
        Task<int> GetLessonIdByLessonNumberAndPart(int lessonNumber, int part);
        Task<QuestionDto> GetQuestionById(int questionId);
        Task<List<QuestionDto>> GetChapterQuizQuestionsByChapterId(int chapterId);
        Task SaveUserFinishedLesson(UserFinishedLessonDto userProgress);
        Task<int> GetTotalLessonsFinished(Guid userId);
    }
}
