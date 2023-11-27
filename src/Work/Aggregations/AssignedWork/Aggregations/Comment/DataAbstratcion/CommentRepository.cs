using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.DataAbstraction;

[RegisterClassAsScoped]
   public class CommentRepository : BaseRepository<CommentModel>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context)
    {
    }
        
    }

