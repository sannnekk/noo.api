using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.Work.Aggregations.AssignedWork.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Services;

public class AssignedWorkService : IAssignedWorkService
{
    protected readonly IAssignedWorkRepository assignedWorkRepository;

    public AssignedWorkService(IAssignedWorkRepository assignedWorkRepository)
    {
        this.assignedWorkRepository = assignedWorkRepository;
    }

    public async Task CreateAsync(AssignedWorkModel model)
    {
        try
        {
            await assignedWorkRepository.CreateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error creating work task: " + e.Message);
        }
    }

    public async Task UpdateAsync(AssignedWorkModel model)
    {
        try
        {
            await assignedWorkRepository.UpdateAsync(model);
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
            var model = await assignedWorkRepository.GetAsync(id);

            if (model == null)
                throw new NotFoundException("AssignedWork not found");

            await assignedWorkRepository.DeleteAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error deleting work task: " + e.Message);
        }
    }

    public async Task<AssignedWorkModel?> GetAsync(Ulid id)
    {
        try
        {
            return await assignedWorkRepository.GetAsync(id);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work task: " + e.Message);
        }
    }

    public async Task<IEnumerable<AssignedWorkModel>> GetAsync()
    {
        try
        {
            return await assignedWorkRepository.GetManyAsync();
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work tasks: " + e.Message);
        }
    }
}