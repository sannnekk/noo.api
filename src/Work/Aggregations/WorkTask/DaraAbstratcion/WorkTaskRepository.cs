using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction;

namespace noo.api.Work.Aggregations.WorkTask.DataAbstraction;

[RegisterClassAsScoped]
   public class WorkTaskRepository : BaseRepository<WorkTaskModel>, IWorkTaskRepository
    {
        public WorkTaskRepository(DataContext context) : base(context)
    {
    }
        
    }

