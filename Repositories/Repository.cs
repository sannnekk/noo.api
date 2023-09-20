namespace api.Repositories;

public class Repository
{
    protected readonly string entityName;

    public Repository(string entityName)
    {
        this.entityName = entityName;
    }

    public virtual IEnumerable<T> Get<T>()
    {
        return new List<T>();
    }
}