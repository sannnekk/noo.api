using Microsoft.EntityFrameworkCore;

namespace noo.api.Core.DataAbstraction;

public abstract class BaseRepository<Model> : IBaseRepository<Model> where Model : BaseModelDefinition
{
    protected DataContext context;

    public BaseRepository(DataContext context)
    {
        this.context = context;
    }

    public async Task<Model?> GetAsync(Predicate<Model> predicate)
    {
        return await context.Set<Model>().FirstOrDefaultAsync(model => predicate(model));
    }

    public async Task<Model?> GetAsync(Ulid id)
    {
        return await context.Set<Model>().FirstOrDefaultAsync(model => model.Id == id);
    }

    public async Task<IEnumerable<Model>> GetManyAsync(Predicate<Model> predicate, Pagination? pagination = null)
    {
        var _query = context.Set<Model>().Where(model => predicate(model));
        var _pagination = pagination ?? new Pagination();

        return await _pagination.Apply(_query).ToListAsync();
    }

    public async Task<IEnumerable<Model>> GetManyAsync(Pagination? pagination = null)
    {
        var _query = context.Set<Model>().AsQueryable();
        var _pagination = pagination ?? new Pagination();

        return await _pagination.Apply(_query).ToListAsync();
    }

    public async Task CreateAsync(Model model)
    {
        await context.Set<Model>().AddAsync(model);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Model model)
    {
        context.Set<Model>().Update(model);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Model model)
    {
        context.Set<Model>().Remove(model);
        await context.SaveChangesAsync();
    }

    public async Task<int> CountAsync(Predicate<Model>? predicate)
    {
        var _predicate = predicate ?? new Predicate<Model>(model => true);

        return await context.Set<Model>().CountAsync(model => _predicate(model));
    }
}