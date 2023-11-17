using noo.api.User.DataAbstraction;

namespace noo.api.User.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserModel model);

        Task UpdateAsync(UserModel model);

        Task DeleteAsync(Ulid id);

        Task<UserModel?> GetAsync(Ulid id);

        Task<IEnumerable<UserModel>> GetAsync();
    }
}
