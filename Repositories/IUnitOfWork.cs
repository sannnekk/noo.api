using api.Repositories.EntityRepositories;

namespace api.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMaterialRepository Materials { get; }
        ISubjectRepository Subjects { get; }
        IWorkRepository Works { get; }
        IAnswerRepository Answers { get; }
        ICommentRepository Comments { get; }
        ITaskRepository Tasks { get; }
        IAssignedWorkRepository AssignedWorks { get; }
        IUserRepository Users { get; }

        int Complete();
    }
}