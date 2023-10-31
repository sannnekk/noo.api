namespace api.Services.Interfaces
{
    public interface IEntityCountable
    {
        Task<int> CountAsync();
    }
}