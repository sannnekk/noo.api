using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.DataAbstraction;

[RegisterClassAsScoped]
   public class AssignedWorkRepository : BaseRepository<AssignedWorkModel>, IAssignedWorkRepository
    {
        public AssignedWorkRepository(DataContext context) : base(context)
    {
    }
        
    }

