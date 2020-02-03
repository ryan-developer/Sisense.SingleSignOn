using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sisense.SingleSignOn
{
    public class SisenseJwtProvider : ISisenseJwtProvider
    {
        public string CreateJwt(SisenseJwtRequest jwtRequest)
        {
            TimeSpan timeSinceEpoch = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            string secondsSinceEpoch = ((int)timeSinceEpoch.TotalSeconds).ToString();

            var claims = new List<Claim> {
                new Claim(JwtClaimTypes.Subject, jwtRequest.EmailAddress),
                new Claim(JwtClaimTypes.IssuedAt, secondsSinceEpoch, ClaimValueTypes.Integer),
                new Claim(JwtClaimTypes.JwtId, Guid.NewGuid().ToString())
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtRequest.SharedSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                notBefore: null,
                expires: null,
                signingCredentials: creds);

            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenValue = tokenHandler.WriteToken(token);
            return tokenValue;
        }
    }
}
