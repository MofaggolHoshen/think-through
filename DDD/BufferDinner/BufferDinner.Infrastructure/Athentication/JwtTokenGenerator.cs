
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BufferDinner.Application.Common.Interfaces.Authentication;
using BufferDinner.Application.Common.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace BufferDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    // Datetime provider
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(
        Guid userId,
        string firstName,
        string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secter-key-1234567890-1234567890-1234567890-1234567890")),
            SecurityAlgorithms.HmacSha256);
            
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "BufferDinner",
            expires: _dateTimeProvider.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler()
                            .WriteToken(securityToken);
    }
}
