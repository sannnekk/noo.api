using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        { }
    }
}
