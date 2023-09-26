using api.Models.DB;
using api.Repositories.EntityRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.EntityRepositories.Implementations
{
    public class SubjectRepository : BaseRepository<SubjectModel>, ISubjectRepository
    {
        public SubjectRepository(DbContext context) : base(context) { }
      
        public async Task<List<SubjectModel>> GetSubjectsWithMaterials(Func<SubjectModel, bool> predicate)
        {
            return await Task.FromResult(
                Context.Set<SubjectModel>()
                .Where(predicate)
                .ToList());
        }

        public async Task<SubjectModel?> GetSubjectWithMaterials(Ulid id)
        {
            return await Context.Set<SubjectModel>()
                .Include(s => s.Materials)
                .FirstOrDefaultAsync(s => s.Id == id);
        }        
    }
}
