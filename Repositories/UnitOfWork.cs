using api.Repositories.EntityRepositories.Implementations;
using api.Repositories.EntityRepositories.Interfaces;

namespace api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Materials = new MaterialRepository(_context);        
        Works = new WorkRepository(_context);
        Answers = new AnswerRepository(_context);
        Comments = new CommentRepository(_context);
        Tasks = new TaskRepository(_context);
        AssignedWorks = new AssignedWorkRepository(_context);
        Users = new UserRepository(_context);
    }

    public IMaterialRepository Materials { get; }    
    public IWorkRepository Works { get; }
    public IAnswerRepository Answers { get; }
    public ICommentRepository Comments { get; }
    public ITaskRepository Tasks { get; }
    public IAssignedWorkRepository AssignedWorks { get; }
    public IUserRepository Users { get; }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.SaveChanges();
        _context.Dispose();
    }
}