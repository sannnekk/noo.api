using api.Models.Auth;
using api.Models.DB;
using api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace api.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        private List<UserModel> test = new List<UserModel>()
        {
            new UserModel
            {
                Id =Ulid.NewUlid(),
                Name = "Mark",
                UserName = "Gulliver",
                PasswordHash = "12345",
                Email = "mark2515@gmail.com",
                UserRole = Models.Enums.UserRole.Teacher
            },
            new UserModel
            {
                Id =Ulid.NewUlid(),
                Name = "Jane",
                UserName = "Cinderella",
                PasswordHash = "12345",
                Email = "jane2516@gmail.com",
                UserRole = Models.Enums.UserRole.Admin
            }
        };

        public UserModel? Authenticate(LoginModel loginModel)
        {
            var currentUser = test.FirstOrDefault(e => e.UserName.ToLower() == loginModel.UserName.ToLower()
                && e.PasswordHash == loginModel.Password);

            return currentUser;
        }

        public string GenerateJWTToken(UserModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Name),
                new Claim(ClaimTypes.Role, nameof(model.UserRole))
            };

            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
