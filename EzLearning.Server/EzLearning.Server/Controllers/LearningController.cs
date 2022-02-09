using System;
using System.Linq;
using System.Threading.Tasks;
using EzLearning.Server.Dal;
using EzLearning.Server.Services.Contracts;
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

        [HttpGet("chapter/{chapterId}/lessons")]
        public async Task<IActionResult> GetLessonsByChapterId([FromRoute] int chapterId)
        {
            _logger.LogInformation($"Returning lessons for chapter id: {chapterId}");
            return await GetResultSafeAsync(async () => await _learningService.GetLessonsByChapterId(chapterId));
        }

        [HttpGet("lesson/{lessonId}")]
        public async Task<IActionResult> GetLessonById([FromRoute] int lessonId)
        {
            _logger.LogInformation($"Returning lesson by lesson id: {lessonId}");
            return await GetResultSafeAsync(async () => await _learningService.GetLessonById(lessonId));
        }

        [HttpGet("lesson/{lessonNumber}/{part}")]
        public async Task<IActionResult> GetLessonIdByLessonNumberAndPart([FromRoute] int lessonNumber, [FromRoute] int part)
        {
            _logger.LogInformation($"Returning lesson id by lesson number: {lessonNumber} and part: {part}");
            return await GetResultSafeAsync(async () => await _learningService.GetLessonIdByLessonNumberAndPart(lessonNumber, part));
        }

        [HttpGet("question/{questionId}")]
        public async Task<IActionResult> GetQuestionById([FromRoute] int questionId)
        {
            _logger.LogInformation($"Returning question by question id: {questionId}");
            return await GetResultSafeAsync(async () => await _learningService.GetQuestionById(questionId));
        }

        [HttpGet("chapter/{chapterId}/questions")]
        public async Task<IActionResult> GetChapterQuizQuestionsByChapterId([FromRoute] int chapterId)
        {
            _logger.LogInformation($"Returning quiz questions by chapter id: {chapterId}");
            return await GetResultSafeAsync(async () => await _learningService.GetChapterQuizQuestionsByChapterId(chapterId));
        }

        [HttpPost("userprogress")]
        public async Task<IActionResult> SaveUserProgress([FromBody] UserFinishedLessonDto userProgress)
        {
            _logger.LogInformation($"Saving lessons finished by user {userProgress.UserId}");
            return await GetResultSafeAsync(() => _learningService.SaveUserFinishedLesson(userProgress));
        }

        [HttpGet("userprogress/{userId}")]
        public async Task<IActionResult> GetTotalLessonsFinished([FromRoute] Guid userId)
        {
            _logger.LogInformation($"Returning number of lessons finished by user {userId}");
            return await GetResultSafeAsync(() => _learningService.GetTotalLessonsFinished(userId));
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

        private async Task<IActionResult> GetResultSafeAsync(Func<Task> action)
        {
            try
            {
                await action();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
