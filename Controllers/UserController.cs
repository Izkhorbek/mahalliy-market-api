using MahalliyMarket.DTOs;
using MahalliyMarket.DTOs.UserDTOs;
using MahalliyMarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MahalliyMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ApiResponse<ConfirmationResponse>>> UserRegistration(UserRegistrationDTO registrationDTO)
        {
            var confirmation = await _userService.RegistrationAsync(registrationDTO);

            return StatusCode(confirmation.status_code, confirmation);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ApiResponse<UserRegistrationDTO>>> Login(UserLoginDTO loginDTO)
        {
            var result = await _userService.LoginAsync(loginDTO);

            return StatusCode(result.status_code, result);
        }

    }
}
