using noo.api.Work.Aggregations.WorkTask.DataAbstraction;

namespace noo.api.Work.Aggregations.WorkTask.Services;

public interface IWorkTaskService
{
    Task CreateAsync(WorkTaskModel model);
    Task UpdateAsync(WorkTaskModel model);
    Task DeleteAsync(Ulid id);
    Task<WorkTaskModel?> GetAsync(Ulid id);
    Task<IEnumerable<WorkTaskModel>> GetAsync();
}
