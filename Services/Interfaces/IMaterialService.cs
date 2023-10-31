using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface IMaterialService : IEntityCreateable<MaterialModel>, IEntityCountable, IEntityGettable<MaterialModel>, IEntityDeleteable<MaterialModel>, IEntityUpdateable<MaterialModel>
    {
        Task<MaterialModel?> GetMaterialWithWorksAsync(Ulid id);
    }
}
