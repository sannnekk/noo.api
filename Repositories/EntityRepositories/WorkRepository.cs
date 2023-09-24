using api.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories
{
    public class WorkRepository : BaseRepository<WorkModel>, IWorkRepository
    {
        public WorkRepository(DbContext context) : base(context)
        { }
    }
}
