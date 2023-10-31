using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface ISubjectService : IEntityCreateable<SubjectModel>, IEntityCountable, IEntityGettable<SubjectModel>, IEntityDeleteable<SubjectModel>, IEntityUpdateable<SubjectModel>
    {
        Task<SubjectModel> GetSubjectWithMaterialsAsync(Ulid id);
    }
}
