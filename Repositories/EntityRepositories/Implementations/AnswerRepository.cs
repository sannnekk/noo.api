using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class AnswerRepository : BaseRepository<AnswerModel>, IAnswerRepository
    {
        public AnswerRepository(DbContext context) : base(context)
        { }
    }
}
