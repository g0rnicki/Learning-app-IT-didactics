using EzLearning.Server.Dal;
using EzLearning.Server.Services.Contracts;
using EzLearning.Server.Services.Interfaces;
using System;
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
            var chapters = from c in _ctx.chapters
                           orderby c.Id ascending
                           select c;
            var result = chapters.Select(c => new ChapterDto { Id = c.Id, Name = c.Name, Available = c.Lessons.Any() }).ToList();
            return Task.FromResult(result);
        }

        public Task<LessonDto> GetLessonById(int lessonId)
        {
            var lessons = from l in _ctx.lessons
                          where l.Id == lessonId
                          select l;
            
            if (!lessons.Any())
            {
                throw new IndexOutOfRangeException("Lesson with provided ID does not exist.");
            }

            return Task.FromResult(new LessonDto
            {
                Id = lessons.First().Id,
                LessonNumber = lessons.First().LessonNumber,
                Part = lessons.First().Part,
                Title = lessons.First().Title,
                Content = lessons.First().Content,
                ChapterId = lessons.First().ChapterId,
                QuestionId = lessons.First().QuestionId
            });
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
