using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoDependencyRegistration.Attributes;
using Microsoft.IdentityModel.Tokens;
using noo.api.Core.Request;

namespace noo.api.Core.Security;

[RegisterClassAsSingleton]
public class JWTService
{
    private readonly IConfiguration _configuration;

    public JWTService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(IDictionary<string, string> payload)
    {
        var configKey = _configuration["Jwt:Key"];
        var configExpiration = _configuration["Jwt:ExpirationInDays"];

        if (configKey == null || configExpiration == null)
            throw new Exception("Jwt secret is not set in appsettings.json");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configKey);

        var subject = new ClaimsIdentity();
        subject.AddClaims(payload.Select(x => new Claim(x.Key, x.Value)));

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(configExpiration)),
            SigningCredentials = signingCredentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public Context DecodeToken(string token)
    {
        var configKey = _configuration["Jwt:Key"];

        if (configKey == null)
            throw new Exception("Jwt secret is not set in appsettings.json");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configKey);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out _);

        return Context.FromClaims(claimsPrincipal.Claims);
    }
}