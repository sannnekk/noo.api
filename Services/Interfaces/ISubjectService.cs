using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectModel> GetSubjectAsync(Ulid id);

        Task<SubjectModel> GetSubjectWithMaterialsAsync(Ulid id);

        Task RemoveSubjectAsync(SubjectModel subject);

        Task CreateSubjectAsync(SubjectModel newSubject);

        Task UpdateSubjectAsync(SubjectModel newSubject);
    }
}
