using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.DataAbstraction;

[RegisterClassAsScoped]
   public class AnswerRepository : BaseRepository<AnswerModel>, IAnswerRepository
    {
        public AnswerRepository(DataContext context) : base(context)
    {
    }
        
    }

