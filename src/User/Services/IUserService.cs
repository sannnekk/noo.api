using noo.api.User.DataAbstraction;

namespace noo.api.User.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserModelDTO modelDTO);

        Task UpdateAsync(UserModel model);

        Task DeleteAsync(Ulid id);

        Task<UserModel?> GetAsync(Ulid id);

        Task<UserModel?> GetUserForLoginAsync(string usernameOrEmail, byte[] password);

        Task<UserModel?> GetByUsernameOrEmail(string username, string email);

        byte[] EncryptPassword(string password);

        Task<IEnumerable<UserModel>> GetAsync();
    }
}
