using AlibabaClone.Application.DTOs.AccountDTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlibabaClone.WebAPI.Authentication
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtGenerator(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public string GenerateToken(AuthResponseDto authResponseDto)
        {
            List<Claim> claims =
            [
                new Claim(JwtRegisteredClaimNames.Sub, authResponseDto.Id.ToString()),
                new Claim("phone", authResponseDto.PhoneNumber)
            ];

            // add roles to claims
            foreach (var role in authResponseDto.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // create the token
            var token = new JwtSecurityToken(issuer:_jwtSettings.Issuer, audience:_jwtSettings.Audience, claims: claims,
                expires:DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
