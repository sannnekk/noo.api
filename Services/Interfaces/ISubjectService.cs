using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectModel> GetSubject(Ulid id);

        Task<SubjectModel> GetSubjectWithMaterials(Ulid id);

        Task RemoveSubject(SubjectModel subject);

        Task CreateSubject(SubjectModel newSubject);

        Task UpdateSubject(SubjectModel newSubject);
    }
}
