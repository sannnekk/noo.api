using noo.api.Core.DataAbstraction;

namespace noo.api.User.DataAbstraction
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        Task<UserModel> GetForLoginAsync(string usernameOrEmail, string password);
    }
}
