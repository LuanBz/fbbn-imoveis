using fbbn.API.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace fbbn.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string GenerateJwtToken()
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];

            if (string.IsNullOrEmpty(secretKey))
                throw new InvalidOperationException("JWT secret not configured");

            var key = Encoding.ASCII.GetBytes(secretKey);

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string Login(LoginDTO request)
        {
            var expectedPassword = _config["AdminPassword"];
            if(request.Senha != expectedPassword)
            {
                throw new UnauthorizedAccessException("Senha incorreta.");
            }
            else
            {
                return GenerateJwtToken();
            }
        }
    }
}
