using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        public JwtProvider(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public string Create(AppUser appUser)
        {
            var claims = new Claim[]
            {
                    new Claim(ClaimTypes.NameIdentifier, appUser.UserName)   
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtOptions.SigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer             = _jwtOptions.Issuer,
                Audience           = _jwtOptions.Audience, 
                Subject            = new ClaimsIdentity(claims),
                Expires            = DateTime.UtcNow.AddSeconds(_jwtOptions.ExpiresInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}