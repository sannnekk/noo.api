using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.Services;

public class AnswerService : IAnswerService
{
    protected readonly IAnswerRepository answerRepository;

    public AnswerService(IAnswerRepository answerRepository)
    {
        this.answerRepository = answerRepository;
    }

    public async Task CreateAsync(AnswerModel model)
    {
        try
        {
            await answerRepository.CreateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error creating work task: " + e.Message);
        }
    }

    public async Task UpdateAsync(AnswerModel model)
    {
        try
        {
            await answerRepository.UpdateAsync(model);
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
            var model = await answerRepository.GetAsync(id);

            if (model == null)
                throw new NotFoundException("Answer not found");

            await answerRepository.DeleteAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error deleting work task: " + e.Message);
        }
    }

    public async Task<AnswerModel?> GetAsync(Ulid id)
    {
        try
        {
            return await answerRepository.GetAsync(id);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work task: " + e.Message);
        }
    }

    public async Task<IEnumerable<AnswerModel>> GetAsync()
    {
        try
        {
            return await answerRepository.GetManyAsync();
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work tasks: " + e.Message);
        }
    }
}