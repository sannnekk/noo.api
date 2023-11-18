using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.User.DataAbstraction;
using System.Security.Cryptography;
using System.Text;

namespace noo.api.User.Services
{
    [RegisterClassAsScoped]
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;        

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(CreateUserModelDTO modelDTO)
        {
            try
            {
                if (GetByUsernameOrEmail(modelDTO.Username, modelDTO.Email) != null)
                    throw new AlreadyExistsException("User with such Username or email already exist!");

                var newUser = new UserModel
                {
                    Id = Ulid.NewUlid(),
                    Slug = GenerateSlug(),
                    Username = modelDTO.Username,
                    Email = modelDTO.Email,
                    PasswordHash = EncryptPassword(modelDTO.Password)
                };

                await _userRepository.CreateAsync(newUser);
            }
            catch (Exception e)
            {
                throw new UnknownException("Error creating user: " + e.Message);
            }
        }

        public byte[] EncryptPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();                        
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));            
        }

        private string GenerateSlug()
        {
            //TODO: Implement GenerateSlug method in UserService
            return string.Empty;
        }

        public async Task DeleteAsync(Ulid id)
        {
            try
            {
                var model = await _userRepository.GetAsync(id);

                if (model == null)
                    throw new NotFoundException("User not found");

                await _userRepository.DeleteAsync(model);
            }
            catch (Exception e)
            {
                throw new UnknownException("Error deleting course: " + e.Message);
            }
        }

        public async Task<UserModel?> GetAsync(Ulid id)
        {
            try
            {
                return await _userRepository.GetAsync(id);             
            }
            catch (Exception e)
            {
                throw new UnknownException("Error getting user: " + e.Message);
            }
        }

        public async Task<UserModel?> GetUserForLoginAsync(string usernameOrEmail, byte[] password)
        {
            try
            {
                return await _userRepository.GetForLoginAsync(usernameOrEmail, password);
            }
            catch(Exception e)
            {
                throw new UnknownException("Error getting user: " + e.Message);
            }
        }

        public async Task<IEnumerable<UserModel>> GetAsync()
        {
            try
            {
                return await _userRepository.GetManyAsync();
            }
            catch (Exception e)
            {
                throw new UnknownException("Error getting users: " + e.Message);
            }
        }

        public async Task UpdateAsync(UserModel model)
        {
            try
            {
                await _userRepository.UpdateAsync(model);
            }
            catch (Exception e)
            {
                throw new UnknownException("Error updating user: " + e.Message);
            }
        }

        public async Task<UserModel?> GetByUsernameOrEmail(string username, string email)
        {
            try
            {
                return await _userRepository.GetByUsernameOrEmail(username, email);               
            }
            catch(Exception e)
            {
                throw new UnknownException("Error getting user: " + e.Message);
            }
        }
    }
}
