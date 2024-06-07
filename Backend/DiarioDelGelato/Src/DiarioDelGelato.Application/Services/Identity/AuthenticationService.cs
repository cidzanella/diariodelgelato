using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Application.Interfaces.Services.Entities;
using DiarioDelGelato.Application.Interfaces.Services.Identity;
using DiarioDelGelato.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Services.Identity
{
    //TODO:: IMPLEMENT IAuthenticationService
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<ServiceResponse<AuthenticationResponseDTO>> LoginAsync(AuthenticationRequestDTO authenticationRequest)
        {
            throw new NotImplementedException();

            // validate credentials: username and password
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return new ServiceResponse<AuthenticationResponseDTO>("Unauthorized! Username and password are required.");

            // verify user on database
            var user = await _userService.ReadUserByUsernameAsync(authenticationRequest.UserName);

            if (user == null)
                return new ServiceResponse<AuthenticationResponseDTO>("Unauthorized! User not found.");

            // generate JWT token

            // return token
        }

        public bool Logout(RevokeTokenRequestDTO revokeTokenRequest)
        {
            //todo: implement logout on Application.Services.Identity
            throw new NotImplementedException();
        }
    }
}
