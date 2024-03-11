using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using application.common.interfaces;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace infrastructure.services;

public class TokenService : ITokenService
{
    public string GenerateToken(Guid idUser, string email, Guid key)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecretKeyForThisWeb")),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, idUser.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, email),
            new Claim(JwtRegisteredClaimNames.UniqueName, key.ToString())
        };
        
        var securityToken = new JwtSecurityToken(
            issuer: "Token this website",
            expires: DateTime.Now.AddDays(1),
            claims: claims,
            signingCredentials: signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}