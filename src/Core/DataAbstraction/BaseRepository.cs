namespace noo.api.Core.DataAbstraction;

public abstract class BaseRepository<Model> where Model : BaseModelDefinition
{
    protected ILoader loader;

    public BaseRepository(ILoader loader)
    {
        this.loader = loader;
    }

    public async Task<Model?> Get(Predicate<Model> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Model>> GetMany(Predicate<Model> predicate)
    {
        throw new NotImplementedException();
    }
}