using api.ModelDefinitions;

namespace api.Repositories;

public class Repository
{
    protected readonly string entityName;

    public Repository(string entityName)
    {
        this.entityName = entityName;
    }

    public virtual IEnumerable<T> Get<T>() where T : IModelDefinition
    {
        return new List<T>();
    }
}