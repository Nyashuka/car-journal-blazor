using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace CarJournal.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid id)
    {
        var signingCredential = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("hs256 key generatorfdsabfdjhsbf ajsdbjkhas asdb")
            ),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
        };

        var securityToken = new JwtSecurityToken(
            claims: claims,
            issuer: "CarJournal",
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signingCredential
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}