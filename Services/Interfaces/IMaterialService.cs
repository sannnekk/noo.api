using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface IMaterialService : IBaseModelsService<MaterialModel>
    {       
        Task<MaterialModel> GetMaterialWithWorksAsync(Ulid id);      
    }
}
