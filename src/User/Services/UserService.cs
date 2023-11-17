using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.User.DataAbstraction;

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

        public async Task CreateAsync(UserModel model)
        {
            try
            {
                await _userRepository.CreateAsync(model);
            }
            catch (Exception e)
            {
                throw new UnknownException("Error creating user: " + e.Message);
            }
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

        public async Task<UserModel?> GetUserForLoginAsync(string usernameOrEmail, string password)
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
    }
}
