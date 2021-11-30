using EzLearning.Server.Models;
using EzLearning.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EzLearning.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthorizeUser([FromBody] AuthorizationRequestBody requestBody)
        {
            _logger.LogInformation($"Authorizing user: {requestBody.Username}");

            var response = await _userService.AuthorizeUserAsync(requestBody.Username, requestBody.Password);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = new { shouldPaint = "black" };
            return Ok(users);
        }
    }
}
