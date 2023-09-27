using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<MaterialModel> GetMaterialAsync(Ulid id);

        Task RemoveMaterialAsync(MaterialModel material);

        Task CreateMaterialAsync(MaterialModel newMaterial);

        Task UpdateMaterialAsync(MaterialModel newMaterial);
    }
}
