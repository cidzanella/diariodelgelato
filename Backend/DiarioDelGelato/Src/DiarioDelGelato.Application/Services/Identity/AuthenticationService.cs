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
            // validate credentials: username and password
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
                return new ServiceResponse<AuthenticationResponseDTO>("Unauthorized! Username and password are required.");

            // verify user on database
            var responseUser = await _userService.ReadUserByUsernameAsync(authenticationRequest.UserName);
            if (!responseUser.Success)
                return new ServiceResponse<AuthenticationResponseDTO>($"Unauthorized! {responseUser.Message}");

            // generate JWT token
            var responseToken= await _tokenService.GenerateAccessTokenAsync(authenticationRequest, responseUser.Data);
            if (!responseToken.Success)
                return new ServiceResponse<AuthenticationResponseDTO>(responseToken.Message);

            var responseDTO = new AuthenticationResponseDTO
            {
                Token = responseToken.Data,
                IsAdmin = responseUser.Data.IsAdmin,
                UserName = responseUser.Data.UserName,
                IsEnabled = responseUser.Data.IsEnabled
            };

            return new ServiceResponse<AuthenticationResponseDTO>(responseDTO);

        }

        // future implementation, not in use
        public async Task<bool> LogoutAsync(RevokeTokenRequestDTO revokeTokenRequest)
        {
            // validate the token
            if (string.IsNullOrWhiteSpace(revokeTokenRequest.Token))
                return false;

            // revoke the token
            await _tokenService.RevokeTokenAsync(revokeTokenRequest);
            return true;
        }
    }
}
