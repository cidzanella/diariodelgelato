using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Application.Interfaces.Services.Identity;
using DiarioDelGelato.Infrastructure.Identity.Settings;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DiarioDelGelato.Application.Wrappers;
using DiarioDelGelato.Domain.Entities;
using DiarioDelGelato.Application.DTOs.Features.UserDTOs;
using DiarioDelGelato.Application.Interfaces.Services.Features;

namespace DiarioDelGelato.Infrastructure.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IPasswordService _passwordService;

        // JWtSettings will come from appsettings.json
        public TokenService(IOptions<JWTSettings> jwtSettings, IPasswordService passwordService )
        {
            _jwtSettings = jwtSettings.Value;
            _passwordService = passwordService;
        }

        public async Task<ServiceResponse<string>> GenerateAccessTokenAsync(AuthenticationRequestDTO authenticationRequest, UserAuthenticationDataReponseDto userAuthenticationData )
        {
            // validate if passwords match
            if (!_passwordService.VerifyPasswordHash(authenticationRequest.Password, userAuthenticationData.PasswordHash, userAuthenticationData.PasswordSalt))
                return new ServiceResponse<string>("Unauthorized! Invalid password.");

            // generate token
            var jwtToken = await GenerateJwtTokenAsync(userAuthenticationData.UserName, userAuthenticationData.IsAdmin);

            // serialize token as string
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwtToken);
            
            return new ServiceResponse<string>(true, "Access token generated.", token);

        }

        private async Task<JwtSecurityToken> GenerateJwtTokenAsync(string userName, bool isAdmin)
        {
            var claims = new List<Claim>
{
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, isAdmin?"ADMIN":"USER")

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: credentials
            );

            return await Task.FromResult(token);
        }

        //
        // Future implementation
        //
        public async Task<ServiceResponse<bool>> RevokeTokenAsync(RevokeTokenRequestDTO revokeTokenRequest)
        {
            //invalidate the user's token by adding its token identifier (e.g., JWT jti claim) to the token blacklist using a TokenRepository
            //important to clear token from frontend storage as well

            throw new NotImplementedException();
        }

        //public async Task<string> GenerateRefreshTokenAsync(RefreshTokenRequest request, string ipAddress)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
