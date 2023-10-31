using api.Models.DB;

namespace api.Services.Interfaces
{
    public interface IWorkService : IEntityCreateable<WorkModel>, IEntityCountable, IEntityGettable<WorkModel>, IEntityDeleteable<WorkModel>, IEntityUpdateable<WorkModel>
    {

    }
}
