using API_46731r.Contracts;
using API_46731r.Domain.Entities.Identity;
using API_46731r.Services.Abstractions;
using API_46731r.Services.Abstractions.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_46731r.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IPasswordHasher<ApplicationUser> _hasher;
        private readonly ITokenService _tokenService;
        private readonly IAuthenticationService _authenticationService;


        public AuthenticationController(IUserService userService, ILogger<AuthenticationController> logger, IPasswordHasher<ApplicationUser> hasher,
                              ITokenService tokenService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _logger = logger;
            _hasher = hasher;
            _tokenService = tokenService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<ActionResult> LogInAsync([FromBody] ApplicationUserViewModel userVM)
        {

            _logger.LogInformation($"Entered {DateTime.Now}");

            var result = await _authenticationService.LogIn(userVM);

            var userDTO = new ApplicationUserDTO()
            {
                Email = result.Email,
                JWT = await _tokenService.GenerateTokenAsync(result),
                Name = result.FirstName,
                SecondName = result.LastName
            };

            _logger.LogInformation($"Response Ok");

            return Ok(userDTO);
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] ApplicationUserViewModel userVM)
        {
            string message = string.Empty;
            var user = await _userService.GetByEmailAsync(userVM.Email);

            if (user is null)
            {
                message = $"User with email '{userVM.Email}' does not exist";
            }

            user.HashedPassword = _hasher.HashPassword(user, userVM.Password.ToString());

            await _userService.Update(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
