using AutoDependencyRegistration.Attributes;
using noo.api.Core.DataAbstraction;

namespace noo.api.Course.DataAbstraction;

[RegisterClassAsScoped]
public class CourseRepository : BaseRepository<CourseModel>, ICourseRepository
{
    public CourseRepository(DataContext context) : base(context)
    {
    }
}