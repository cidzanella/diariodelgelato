using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Application.Interfaces.Services.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiarioDelGelato.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponseDTO>> Login(AuthenticationRequestDTO authenticationRequest)
        {
            //TODO: review Login
            var response = await _authenticationService.LoginAsync(authenticationRequest);
            if (response.Success)
                return RedirectToAction("Index", "Home");
            return BadRequest(response.Message);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<bool>> Logout(RevokeTokenRequestDTO revokeTokenRequest)
        {
            //TODO: review Logout
            return Ok(_authenticationService.Logout(revokeTokenRequest));
        }

    }
}
