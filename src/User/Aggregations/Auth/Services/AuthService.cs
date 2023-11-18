using AutoDependencyRegistration.Attributes;
using Microsoft.IdentityModel.Tokens;
using noo.api.Auth.DataAbstraction;
using noo.api.Auth.Exceptions;
using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.User.DataAbstraction;
using noo.api.User.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace noo.api.Auth.Services
{
    [RegisterClassAsScoped]
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthService(IConfiguration config, IUserService userService)
        {
            _config = config;
           _userService = userService;
        }

        public async Task<UserModel> AuthenticateAsync(LoginModel loginModel)
        {
            var passwordHash = _userService.EncryptPassword(loginModel.Password);
            var currentUser = await _userService.GetUserForLoginAsync(loginModel.UsernameOrEmail, passwordHash);

            if(currentUser == null)          
                throw new NotFoundException("Wrong login or password");
            
            return currentUser;
        }

        public string GenerateJWTToken(UserModel model)
        {
            if(model == null)
                throw new ArgumentNullException();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var expirationTime = _config["Jwt:ExpirationInDays"];

            if (securityKey == null || expirationTime == null)
                throw new JwtMissingOptionsException("Jwt Key or ExpirationDate is not set in appsettings.json");

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.GivenName, model.Username),                
                new Claim(ClaimTypes.Role, model.Role.ToString())
            };  
            
            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddDays(Convert.ToInt32(expirationTime)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }      
    }
}
