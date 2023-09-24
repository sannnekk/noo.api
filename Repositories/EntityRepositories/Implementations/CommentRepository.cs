using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class CommentRepository : BaseRepository<CommentModel>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        { }
    }
}
