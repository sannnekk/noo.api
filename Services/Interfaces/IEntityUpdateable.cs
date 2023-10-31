namespace api.Services.Interfaces
{
    public interface IEntityUpdateable<T>
    {
        Task UpdateAsync(T entity);
    }
}