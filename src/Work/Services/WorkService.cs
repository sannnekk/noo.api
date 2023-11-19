using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.Work.DataAbstraction;

namespace noo.api.Work.Services;

public class WorkService : IWorkService
{
    protected readonly IWorkRepository workRepository;

    public WorkService(IWorkRepository workRepository)
    {
        this.workRepository = workRepository;
    }

    public async Task CreateAsync(WorkModel model)
    {
        try
        {
            await workRepository.CreateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error creating work: " + e.Message);
        }
    }

    public async Task UpdateAsync(WorkModel model)
    {
        try
        {
            await workRepository.UpdateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error updating work: " + e.Message);
        }
    }

    public async Task DeleteAsync(Ulid id)
    {
        try
        {
            var model = await workRepository.GetAsync(id);

            if (model == null)
                throw new NotFoundException("Work not found");

            await workRepository.DeleteAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error deleting work: " + e.Message);
        }
    }

    public async Task<WorkModel?> GetAsync(Ulid id)
    {
        try
        {
            return await workRepository.GetAsync(id);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting work: " + e.Message);
        }
    }

    public async Task<IEnumerable<WorkModel>> GetAsync()
    {
        try
        {
            return await workRepository.GetManyAsync();
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting works: " + e.Message);
        }
    }
}