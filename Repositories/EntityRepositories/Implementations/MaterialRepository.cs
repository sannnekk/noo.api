using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class MaterialRepository : BaseRepository<MaterialModel>, IMaterialRepository
    {
        public MaterialRepository(DbContext context) : base(context)
        { }
    }
}
