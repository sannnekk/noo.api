using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class AssignedWorkRepository : BaseRepository<AssignedWorkModel>, IAssignedWorkRepository
    {
        public AssignedWorkRepository(DbContext context) : base(context)
        { }
    }
}
