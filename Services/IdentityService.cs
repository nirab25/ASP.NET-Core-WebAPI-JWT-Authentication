using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

using DotNetCoreJWTAuth.Config;
using DotNetCoreJWTAuth.Models;
using DotNetCoreJWTAuth.Models.v1.Requests;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace DotNetCoreJWTAuth.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly JwtSettings _jwtSettings;
        public readonly UserManager<IdentityUser> _userManager;

        public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthenticationResult> RegisterAsync(UserRegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Username already exists!"}
                };
            }

            var newUsr = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var createdUser = await _userManager.CreateAsync(newUsr, request.Password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUsr.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUsr.Email),
                    new Claim("id", newUsr.Id),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
