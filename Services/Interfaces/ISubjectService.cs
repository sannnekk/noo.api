using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface ISubjectService : IBaseModelsService<SubjectModel>
    {      
        Task<SubjectModel> GetSubjectWithMaterialsAsync(Ulid id);
      
    }
}
