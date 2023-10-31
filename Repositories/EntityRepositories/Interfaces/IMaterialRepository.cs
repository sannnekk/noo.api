using api.Models.DB;

namespace api.Repositories.EntityRepositories.Interfaces
{
    public interface IMaterialRepository : IRepository<MaterialModel>
    {
        Task<MaterialModel?> GetMaterialWithWorks(Ulid id);

        Task<IEnumerable<MaterialModel>> GetGetMaterialsWithWorks(Func<MaterialModel, bool> predicate);
    }
}
