using System.Linq;
using System.Threading.Tasks;
using EzLearning.Server.Dal;
using Microsoft.AspNetCore.Mvc;

namespace EzLearning.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LearningController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public LearningController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("lesson")]
        public Task<IActionResult> GetAllChapterLessons()
        {
            var allLessonsQuery = from lesson in _ctx.lessons
                                  select lesson;
            return Task.FromResult<IActionResult>(Ok(allLessonsQuery.ToList()));
        }
    }
}
