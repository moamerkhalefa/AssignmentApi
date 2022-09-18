using MaqtaAssignment.AppServices;
using MaqtaAssignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaqtaAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.RegisterAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(new { success = false, isAuthenticated = false, token = "", expiresOn = "", email = "", username = "", message = result.Message });
            }
            return Ok(new { success = true, isAuthenticated = true, token = result.Token, expiresOn = result.ExpiresOn, email = result.Email, username = result.Username, message = result.Message });
        }
        [HttpPost("login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authService.GetTokenAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(new { success = false, isAuthenticated = false, token = "", expiresOn = "", email = "", username = "", message = result.Message });
            }
            return Ok(new { success = true, isAuthenticated = true, token = result.Token, expiresOn = result.ExpiresOn, email = result.Email, username = result.Username, message = result.Message });
        }
        [Authorize]
        [HttpGet("GetUserProfile")]
        public async Task<object> GetUserProfileAsync()
        {
            string userId = User.Claims.First(c => c.Type == "uid").Value;
            var result = await _authService.GetUserAsync(userId);
            return result;
        }
    }
}
