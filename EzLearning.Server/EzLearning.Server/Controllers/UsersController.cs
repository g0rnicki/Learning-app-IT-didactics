using EzLearning.Server.Models;
using EzLearning.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EzLearning.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] AuthorizationRequestBody requestBody)
        {
            _logger.LogInformation($"Authorizing user: {requestBody.Username}");

            var response = await _userService.LoginUserAsync(requestBody.Username, requestBody.Password);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestBody requestBody)
        {
            _logger.LogInformation($"Registering user: {requestBody.Username}");
            return await GetResultSafeAsync(() => _userService.RegisterUserAsync(requestBody.Username, requestBody.Email, requestBody.Password));
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = new { shouldPaint = "black" };
            return Ok(users);
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
