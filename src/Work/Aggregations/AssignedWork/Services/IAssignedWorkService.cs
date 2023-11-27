using noo.api.Work.Aggregations.AssignedWork.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Services;

public interface IAssignedWorkService
{
    Task CreateAsync(AssignedWorkModel model);
    Task UpdateAsync(AssignedWorkModel model);
    Task DeleteAsync(Ulid id);
    Task<AssignedWorkModel?> GetAsync(Ulid id);
    Task<IEnumerable<AssignedWorkModel>> GetAsync();
}
