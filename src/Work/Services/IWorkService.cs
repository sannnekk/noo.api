using noo.api.Work.DataAbstraction;

namespace noo.api.Work.Services;

public interface IWorkService
{
    Task CreateAsync(WorkModel model);
    Task UpdateAsync(WorkModel model);
    Task DeleteAsync(Ulid id);
    Task<WorkModel?> GetAsync(Ulid id);
    Task<IEnumerable<WorkModel>> GetAsync();
}
