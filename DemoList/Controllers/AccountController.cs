using AutoMapper;
using DemoList.Data;
using DemoList.Models;
using DemoList.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        public AccountController(UserManager<ApiUser> userManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager)
        {
            _userManager= userManager;
            _logger= logger;
            _mapper= mapper;
            _authManager= authManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt  for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user =_mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)} ");
                return Problem($"Something went  wrong  in the {nameof(Register)}", statusCode: 500);
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUser)
        {
            _logger.LogInformation($"Login Attempt  for {loginUser.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authManager.ValidateUser(loginUser))
                {
                    return Unauthorized();
                }
                return Accepted(new {Token = await _authManager.CreateToken()});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Login)} ");
                return Problem($"Something went  wrong  in the {nameof(Login)}", statusCode: 500);
            }
        }
    }
}
