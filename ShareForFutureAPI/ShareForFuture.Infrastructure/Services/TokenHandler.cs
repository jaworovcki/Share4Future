using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShareForFuture.Domain.DomainModels;
using ShareForFututre.Application.Contracts.Services;

namespace ShareForFuture.Infrastructure.Services;

public class TokenHandler : ITokenHandler
{
    private readonly SymmetricSecurityKey _symmetricSecurityKey;
    private readonly IConfiguration _config;

    public TokenHandler(IConfiguration config)
    {
        _config = config;
        _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    }
    
    public string CreateAccessToken(User user, IEnumerable<string> roles)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
        };
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var credentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:ExpiryInDays"])),
            SigningCredentials = credentials,
            Issuer = _config["Jwt:Issuer"],
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}