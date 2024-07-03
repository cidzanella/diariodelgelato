using DiarioDelGelato.Application.DTOs.Features.UserDTOs;
using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Application.Wrappers;
using DiarioDelGelato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services.Identity
{
    public interface ITokenService
    {
        Task<ServiceResponse<string>> GenerateAccessTokenAsync(AuthenticationRequestDTO authenticationRequest, UserAuthenticationDataReponseDto userAuthenticationDataReponse);

        Task<ServiceResponse<bool>> RevokeTokenAsync(RevokeTokenRequestDTO revokeTokenRequest);

        // future implementation:
        // string GenerateRefreshToken();
        // ValidateRefreshToken(string refreshToken);
        // GenerateAccessTokenFromRefreshToken(string refreshToken);

        /*
         Common methods on Token Services might include:
        GenerateAccessToken: Generate an access token for a user based on their identity and any necessary claims or permissions.
        GenerateRefreshToken: Generate a refresh token used for renewing access tokens without requiring users to log in again.
        InvalidateToken: Invalidate or revoke a token, typically used during logout or in response to security incidents.
        ValidateToken: Validate the integrity and authenticity of a token to ensure it hasn't been tampered with or forged.
        RefreshTokenExpiration: Handle the expiration and renewal of refresh tokens according to security policies.
        BlacklistToken: Add a token to a blacklist to prevent its further use, especially in response to security threats or breaches.
        TokenCleanup: Perform periodic cleanup tasks to remove expired tokens or tokens that are no longer needed.
         * */


    }
}
