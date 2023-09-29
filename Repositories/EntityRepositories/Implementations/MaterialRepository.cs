using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class MaterialRepository : BaseRepository<MaterialModel>, IMaterialRepository
    {
        public MaterialRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<MaterialModel>> GetGetMaterialsWithWorks(Func<MaterialModel, bool> predicate)
        {
            return await Task.FromResult(
                Context.Set<MaterialModel>()
                .Include(m => m.Works)
                .Where(predicate)
                .ToList());
        }

        public async Task<MaterialModel?> GetMaterialWithWorks(Ulid id)
        {
            return await Context.Set<MaterialModel>()
                .Include(m => m.Works)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
