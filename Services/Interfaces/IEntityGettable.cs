namespace api.Services.Interfaces
{
    public interface IEntityGettable<T>
    {
        Task<T?> GetAsync(Ulid id);
        Task<IEnumerable<T>> GetManyAsync(Func<T, bool> predicate);
    }
}