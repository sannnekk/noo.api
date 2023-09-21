using api.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories
{
    public class SubjectRepository : BaseRepository<SubjectModel>, ISubjectRepository
    {
        public SubjectRepository(DbContext context) : base(context)
        { }
    }
}
