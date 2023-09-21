using api.Models.DB;

namespace api.Repositories;

public interface IRepository<T> where T : BaseModel
{
    Task<T?> Get(Ulid id);

    Task<IEnumerable<T>> GetMany(Func<T, bool> predicate);

    Task Add(T entity);

    Task Delete(T entity);

    Task<int> Count();
}

