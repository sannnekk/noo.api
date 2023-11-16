namespace noo.api.Core.DataAbstraction;

public interface IBaseRepository<Model> where Model : BaseModelDefinition
{
    Task CreateAsync(Model model);
    Task UpdateAsync(Model model);
    Task DeleteAsync(Model model);
    Task<Model?> GetAsync(Ulid id);
    Task<Model?> GetAsync(Predicate<Model> predicate);
    Task<IEnumerable<Model>> GetManyAsync(Predicate<Model> predicate, Pagination? pagination = null);
    Task<IEnumerable<Model>> GetManyAsync(Pagination? pagination = null);
    Task<int> CountAsync(Predicate<Model>? predicate);
}