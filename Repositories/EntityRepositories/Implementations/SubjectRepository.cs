using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class SubjectRepository : BaseRepository<SubjectModel>, ISubjectRepository
    {
        public SubjectRepository(DbContext context) : base(context)
        { }
    }
}
