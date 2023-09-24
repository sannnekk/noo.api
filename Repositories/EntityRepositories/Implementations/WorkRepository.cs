using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class WorkRepository : BaseRepository<WorkModel>, IWorkRepository
    {
        public WorkRepository(DbContext context) : base(context)
        { }
    }
}
