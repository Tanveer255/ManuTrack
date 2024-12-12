﻿using JwtAuthentication.Interface;
using JwtAuthentication.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.Service
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _configuration;

        public JwtAuthenticationService(IOptions<JwtSettings> jwtSettings, IConfiguration configuration)
        {
            _jwtSettings = jwtSettings.Value;
            _configuration = configuration;
        }

        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            // Add more claims if needed
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
