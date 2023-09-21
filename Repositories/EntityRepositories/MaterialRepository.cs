using api.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories
{
    public class MaterialRepository : BaseRepository<MaterialModel>, IMaterialRepository
    {
        public MaterialRepository(DbContext context) : base(context)
        { }
    }
}
