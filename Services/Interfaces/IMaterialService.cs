using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface IMaterialService : IModelsBaseService<MaterialModel>
    {       
        Task<MaterialModel> GetMaterialWithWorksAsync(Ulid id);      
    }
}
