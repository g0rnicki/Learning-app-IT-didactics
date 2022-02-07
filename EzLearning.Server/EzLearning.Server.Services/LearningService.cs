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
            var chapters = from c in _ctx.chapters
                           select c;
            var result = chapters.Select(c => new ChapterDto { Id = c.Id, Name = c.Name, Available = false }).ToList();
            result[0].Available = true;
            return Task.FromResult(result);
        }
    }
}
