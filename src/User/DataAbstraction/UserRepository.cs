using AutoDependencyRegistration.Attributes;
using Microsoft.EntityFrameworkCore;
using noo.api.Core.DataAbstraction;

namespace noo.api.User.DataAbstraction
{
    [RegisterClassAsScoped]
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }

        public async Task<UserModel?> GetByUsernameOrEmail(string username, string email)
        {
            return await context
                .Set<UserModel>()
                .FirstOrDefaultAsync(e => e.Username == username || e.Email == email);
        }

        public async Task<UserModel?> GetForLoginAsync(string usernameOrEmail, byte[] password)
        {
            return await context
                .Set<UserModel>()
                .FirstOrDefaultAsync
                (e => (e.Username == usernameOrEmail || e.Email == usernameOrEmail) && e.PasswordHash == password);
        }
    }
}
