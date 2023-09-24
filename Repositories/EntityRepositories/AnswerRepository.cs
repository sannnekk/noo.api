using api.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories
{
    public class AnswerRepository : BaseRepository<AnswerModel>, IAnswerRepository
    {
        public AnswerRepository(DbContext context) : base(context)
        { }
    }
}
