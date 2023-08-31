namespace api.Repositories;

public class RepositoryFactory
{
    private readonly IServiceProvider _serviceProvider;

    public RepositoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T GetRepository<T>() where T : Repository
    {
        return (T)_serviceProvider.GetService(typeof(T));
    }
}