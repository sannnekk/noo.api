using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction;

namespace noo.api.Work.DataAbstraction;

[RegisterClassAsScoped]
   public class WorkRepository : BaseRepository<WorkModel>, IWorkRepository
    {
        public WorkRepository(DataContext context) : base(context)
    {
    }
        
    }

