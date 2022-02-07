using EzLearning.Server.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EzLearning.Server.Services.Interfaces
{
    public interface ILearningService
    {
        Task<List<ChapterDto>> GetAllChapters();
    }
}
