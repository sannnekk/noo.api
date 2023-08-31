using api.Repositories;

namespace api.Services;

public class SomeService
{
    // TODO: inject these
    protected readonly RepositoryFactory repositoryFactory;

    public SomeService()
    {

    }

    public IEnumerable<string> Get()
    {
        return new List<string>();
    }
}