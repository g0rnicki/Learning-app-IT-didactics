using EzLearning.Server.Dal;
using EzLearning.Server.Services.Contracts;
using EzLearning.Server.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzLearning.Server.Services
{
    public class LearningService : ILearningService
    {
        private readonly AppDataContext _ctx;

        public LearningService(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<ChapterDto>> GetAllChapters()
        {
            //var chapters = from c in _ctx.chapters
            //               join l in _ctx.lessons on c.Id equals l.ChapterId into lessonsGroup
            //               orderby c.Id ascending
            //               select new { c, Available = lessonsGroup };
            //var result = chapters.Select(c => new ChapterDto { Id = c.c.Id, Name = c.c.Name, Available = c.Available.Any() }).ToList();
            var chapters = from c in _ctx.chapters
                           orderby c.Id ascending
                           select c;
            var result = chapters.Select(c => new ChapterDto { Id = c.Id, Name = c.Name }).ToList();
            result[0].Available = true;
            return Task.FromResult(result);
        }

        public Task<List<LessonDto>> GetLessonsByChapterId(int chapterId)
        {
            var lessons = from l in _ctx.lessons
                          where l.ChapterId == chapterId
                          orderby l.Id ascending
                          select l;
            var result = lessons.Select(
                l => new LessonDto
                {
                    Id = l.Id,
                    LessonNumber = l.LessonNumber,
                    Part = l.Part,
                    Title = l.Title,
                    Content = l.Content,
                    ChapterId = l.ChapterId,
                    QuestionId = l.QuestionId
                }).ToList();
            return Task.FromResult(result);
        }
    }
}
