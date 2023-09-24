using api.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories
{
    public class CommentRepository : BaseRepository<CommentModel>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        { }
    }
}
