using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Application.Interfaces.Services.Entities;
using DiarioDelGelato.Application.Interfaces.Services.Identity;
using DiarioDelGelato.Infrastructure.Identity.Settings;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

        public async Task<AuthenticationResponseDTO> GenerateAccessTokenAsync(AuthenticationRequestDTO authenticationRequest)
        {
            // check if username is null or empty
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName))
                throw new ArgumentNullException("Username cannot be null or empty.", nameof(authenticationRequest.UserName));

            // check if password is null or empty
            if (string.IsNullOrWhiteSpace(authenticationRequest.Password))
                throw new ArgumentNullException("Password cannot be null or empty.", nameof(authenticationRequest.Password));
            
            // validate if username exists
            var response = await _userService.ReadUserByUsernameAsync(authenticationRequest.UserName);
            if (!response.Success)
                throw new ArgumentNullException("User not found.", nameof(authenticationRequest.UserName));

            // retrive password hash and salt
            var (storedPasswordHash, storedPasswordSalt) = await _userService.GetUserPasswordDataAsync(response.Data.Id);
            
            // validate if passwords match
            if (!_passwordService.VerifyPasswordHash(authenticationRequest.Password, storedPasswordHash, storedPasswordSalt))
                throw new ArgumentNullException("Invalid password.", nameof(authenticationRequest.Password));

            // generate token
            var jwtToken = await GenerateJwtTokenAsync(authenticationRequest.UserName);
            
            var responseDTO = new AuthenticationResponseDTO
            {
                Token = jwtToken,
                IsAdmin = response.Data.IsAdmin,
                UserName = response.Data.UserName,
                IsEnabled = response.Data.IsEnabled
            };

            return responseDTO;
        }

        public void RevokeToken(RevokeTokenRequestDTO revokeTokenRequest)
        {
            //invalidate the user's token by adding its token identifier (e.g., JWT jti claim) to the token blacklist.
            //important to clear token from frontend storage as well

            throw new NotImplementedException();
        }

        private async Task<string> GenerateJwtTokenAsync(string userName)
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
            
            var tokenHandler = new JwtSecurityTokenHandler();
            return await Task.FromResult(tokenHandler.WriteToken(token));

        }

        //public async Task<string> GenerateRefreshTokenAsync(RefreshTokenRequest request, string ipAddress)
        //{ 
        //    throw new NotImplementedException();
        //}
    }
}
