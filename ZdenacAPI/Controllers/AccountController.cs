using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zdenac_API.Models.DTOs;

namespace Zdenac_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager, ILogger<AccountController> logger, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<ApiUser>(userDTO);
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest("User Register Attempt Failed");
            }

            return Accepted();

        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized(userDTO);
            }

            return Accepted();

        }
    }
}
