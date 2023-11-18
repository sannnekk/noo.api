using noo.api.Auth.DataAbstraction;
using noo.api.User.DataAbstraction;

namespace noo.api.Auth.Services
{
    public interface IAuthService
    {        
        /// <summary>
        /// Check whether such a user exists
        /// </summary>        
        Task<UserModel>? AuthenticateAsync(LoginModel model);

        /// <summary>
        /// Save in claims all necessary information
        /// and generate JWT token
        /// </summary>      
        /// <returns>JWT token as a string</returns>
        string GenerateJWTToken(UserModel model);      
    }
}
