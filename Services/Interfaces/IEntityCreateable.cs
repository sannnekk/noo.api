namespace api.Services.Interfaces
{
    public interface IEntityCreateable<T>
    {
        Task CreateAsync(T entity);
    }
}