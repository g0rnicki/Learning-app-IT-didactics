using System;
using System.Linq;
using System.Threading.Tasks;
using EzLearning.Server.Dal;
using EzLearning.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EzLearning.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LearningController : ControllerBase
    {
        private readonly ILearningService _learningService;
        private readonly ILogger<LearningController> _logger;

        public LearningController(ILearningService learningService, ILogger<LearningController> logger)
        {
            _learningService = learningService;
            _logger = logger;
        }

        //[HttpGet("lesson")]
        //public Task<IActionResult> GetAllChapterLessons()
        //{
        //    var allLessonsQuery = from lesson in _ctx.lessons
        //                          select lesson;
        //    return Task.FromResult<IActionResult>(Ok(allLessonsQuery.ToList()));
        //}

        [HttpGet("chapter")]
        public async Task<IActionResult> GetAllChapters()
        {
            _logger.LogInformation("Returning all Chapters");
            return await GetResultSafeAsync(async () => await _learningService.GetAllChapters());
        }

        private async Task<IActionResult> GetResultSafeAsync<T>(Func<Task<T>> action)
        {
            try
            {
                var result = await action();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
