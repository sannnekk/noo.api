using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface ISubjectService : IModelsBaseService<SubjectModel>
    {      
        Task<SubjectModel> GetSubjectWithMaterialsAsync(Ulid id);
      
    }
}
