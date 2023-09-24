using api.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories
{
    public class AssignedWorkRepository : BaseRepository<AssignedWorkModel>, IAssignedWorkRepository
    {
        public AssignedWorkRepository(DbContext context) : base(context)
        { }
    }
}
