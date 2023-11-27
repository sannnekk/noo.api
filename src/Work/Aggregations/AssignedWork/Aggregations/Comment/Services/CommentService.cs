using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.Services;

public class CommentService : ICommentService
{
    protected readonly ICommentRepository commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }

    public async Task CreateAsync(CommentModel model)
    {
        try
        {
            await commentRepository.CreateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error creating work task: " + e.Message);
        }
    }

    public async Task UpdateAsync(CommentModel model)
    {
        try
        {
            await commentRepository.UpdateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error updating work task: " + e.Message);
        }
    }

    public async Task DeleteAsync(Ulid id)
    {
        try
        {
            var model = await commentRepository.GetAsync(id);

            if (model == null)
                throw new NotFoundException("Comment not found");

            await commentRepository.DeleteAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error deleting work task: " + e.Message);
        }
    }

    public async Task<CommentModel?> GetAsync(Ulid id)
    {
        try
        {
            return await commentRepository.GetAsync(id);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work task: " + e.Message);
        }
    }

    public async Task<IEnumerable<CommentModel>> GetAsync()
    {
        try
        {
            return await commentRepository.GetManyAsync();
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work tasks: " + e.Message);
        }
    }
}