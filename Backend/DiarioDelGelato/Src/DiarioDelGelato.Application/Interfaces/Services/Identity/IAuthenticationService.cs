using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services.Identity
{
    public interface IAuthenticationService
    {
        // login
        Task<ServiceResponse<AuthenticationResponseDTO>> LoginAsync(AuthenticationRequestDTO authenticationRequest); //user and pass
        Task<bool> LogoutAsync(RevokeTokenRequestDTO revokeTokenRequest); //user

        /* 
         * Common methods for Authentication Services:
         * ???? YAGNI (You Ain't Gonna Need It) ????
         * 
        Login: Authenticate a user based on provided credentials(username/password) and generate access and refresh tokens.
        Logout: Invalidate tokens associated with the user, effectively logging them out of the system. Insert into blacklist. Set the revoke date.
        RenewAccessToken: Generate a new access token using a refresh token to extend the user's session.
        AuthenticateToken: Validate and verify the authenticity of a provided token(access or refresh).
        ChangePassword: Allow users to change their passwords securely.
        ForgotPassword: Initiate the process for resetting a forgotten password.
        Authorize: Check if a user has permission to access a specific resource or perform a certain action.
        */
    }
}
