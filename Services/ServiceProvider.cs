namespace api.Services
{
    public class ServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}