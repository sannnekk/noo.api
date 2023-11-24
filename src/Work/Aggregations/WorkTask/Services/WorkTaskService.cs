using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.Work.Aggregations.WorkTask.DataAbstraction;

namespace noo.api.Work.Aggregations.WorkTask.Services;

public class WorkTaskService : IWorkTaskService
{
    protected readonly IWorkTaskRepository workTaskRepository;

    public WorkTaskService(IWorkTaskRepository workTaskRepository)
    {
        this.workTaskRepository = workTaskRepository;
    }

    public async Task CreateAsync(WorkTaskModel model)
    {
        try
        {
            await workTaskRepository.CreateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error creating work task: " + e.Message);
        }
    }

    public async Task UpdateAsync(WorkTaskModel model)
    {
        try
        {
            await workTaskRepository.UpdateAsync(model);
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
            var model = await workTaskRepository.GetAsync(id);

            if (model == null)
                throw new NotFoundException("WorkTask not found");

            await workTaskRepository.DeleteAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error deleting work task: " + e.Message);
        }
    }

    public async Task<WorkTaskModel?> GetAsync(Ulid id)
    {
        try
        {
            return await workTaskRepository.GetAsync(id);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work task: " + e.Message);
        }
    }

    public async Task<IEnumerable<WorkTaskModel>> GetAsync()
    {
        try
        {
            return await workTaskRepository.GetManyAsync();
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work tasks: " + e.Message);
        }
    }
}