namespace api.Services.Interfaces
{
    public interface IEntityDeleteable<T>
    {
        Task DeleteAsync(Ulid id);
    }
}