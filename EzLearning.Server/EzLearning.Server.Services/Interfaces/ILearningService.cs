using EzLearning.Server.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EzLearning.Server.Services.Interfaces
{
    public interface ILearningService
    {
        Task<List<ChapterDto>> GetAllChapters();
        Task<List<LessonDto>> GetLessonsByChapterId(int chapterId);
        Task<LessonDto> GetLessonById(int lessonId);
        Task<QuestionDto> GetQuestionById(int questionId);
    }
}
