using noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.Services;

public interface ICommentService
{
    Task CreateAsync(CommentModel model);
    Task UpdateAsync(CommentModel model);
    Task DeleteAsync(Ulid id);
    Task<CommentModel?> GetAsync(Ulid id);
    Task<IEnumerable<CommentModel>> GetAsync();
}
