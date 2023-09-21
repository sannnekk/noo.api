using api.Models.Auth;
using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Check whether such a user exists
        /// </summary>        
        UserModel Authenticate(LoginModel model);

        /// <summary>
        /// Save in claims all necessary information
        /// and generate JWT token
        /// </summary>      
        /// <returns>JWT token as a string</returns>
        string GenerateJWTToken(UserModel model);
    }
}
