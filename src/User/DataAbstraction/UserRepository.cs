using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction;

namespace noo.api.User.DataAbstraction
{
    [RegisterClassAsScoped]
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }
    }
}
