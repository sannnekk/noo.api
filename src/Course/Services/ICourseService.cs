using noo.api.Course.DataAbstraction;

namespace noo.api.Course.Services;

public interface ICourseService
{
    Task CreateAsync(CourseModel model);
    Task UpdateAsync(CourseModel model);
    Task DeleteAsync(Ulid id);
    Task<CourseModel?> GetAsync(Ulid id);
    Task<IEnumerable<CourseModel>> GetAsync();
}