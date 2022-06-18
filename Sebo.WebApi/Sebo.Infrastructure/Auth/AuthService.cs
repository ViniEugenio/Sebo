using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sebo.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sebo.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration Configuration;

        public AuthService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public string GenerateJWTToken(string Email, string Role)
        {

            string Section = "JWT";
            var issuer = Configuration[$"{Section}:Issuer"];
            var audience = Configuration[$"{Section}:Audience"];
            var key = Configuration[$"{Section}:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new Claim("Email",Email),
                new Claim(ClaimTypes.Role,Role)
            };

            var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddHours(8),
                    signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
    }
}
