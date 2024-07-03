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
        public async Task<ActionResult<AuthenticationResponseDTO>> Login([FromBody] AuthenticationRequestDTO authenticationRequest)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authenticationService.LoginAsync(authenticationRequest);

            if (response.Success)
                return Ok(response.Data);

            return BadRequest(response.Message);
        }

        // logout is not used in the backend api, token revocation is handled by the frontend only
        [HttpPost("logout")]
        public async Task<ActionResult<bool>> Logout([FromBody] RevokeTokenRequestDTO revokeTokenRequest)
        {
            // validate the token
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // revoke the token and reponse back
            if (await _authenticationService.LogoutAsync(revokeTokenRequest))
                return Ok(true);
            return BadRequest("Failed to revoke Token on logout.");
        }

    }
}
