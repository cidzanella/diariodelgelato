using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Application.Interfaces.Services.Entities;
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

namespace DiarioDelGelato.Infrastructure.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        // JWtSettings will come from appsettings.json
        public TokenService(IOptions<JWTSettings> jwtSettings, IUserService userService, IPasswordService passwordService )
        {
            _jwtSettings = jwtSettings.Value;
            _userService = userService;
            _passwordService = passwordService;
        }

        public async Task<ServiceResponse<string>> GenerateAccessTokenAsync(AuthenticationRequestDTO authenticationRequest, UserResponseDto user )
        {
            // retrive password hash and salt
            var (storedPasswordHash, storedPasswordSalt) = await _userService.GetUserPasswordDataAsync(user.Id);
            
            // validate if passwords match
            if (!_passwordService.VerifyPasswordHash(authenticationRequest.Password, storedPasswordHash, storedPasswordSalt))
                return new ServiceResponse<string>("Unauthorized! Invalid password.");

            // generate token
            var jwtToken = await GenerateJwtTokenAsync(authenticationRequest.UserName);

            // serialize token as string
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwtToken);
            
            return new ServiceResponse<string>(token);

        }

        private async Task<JwtSecurityToken> GenerateJwtTokenAsync(string userName)
        {
            var claims = new List<Claim>
{
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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
