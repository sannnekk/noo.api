using noo.api.Core.DataAbstraction.Exceptions;
using noo.api.Course.DataAbstraction;

namespace noo.api.Course.Services;

public class CourseService : ICourseService
{
    protected readonly ICourseRepository courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        this.courseRepository = courseRepository;
    }

    public async Task CreateAsync(CourseModel model)
    {
        try
        {
            await courseRepository.CreateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error creating course: " + e.Message);
        }
    }

    public async Task UpdateAsync(CourseModel model)
    {
        try
        {
            await courseRepository.UpdateAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error updating course: " + e.Message);
        }
    }

    public async Task DeleteAsync(Ulid id)
    {
        try
        {
            var model = await courseRepository.GetAsync(id);

            if (model == null)
                throw new NotFoundException("Course not found");

            await courseRepository.DeleteAsync(model);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error deleting course: " + e.Message);
        }
    }

    public async Task<CourseModel?> GetAsync(Ulid id)
    {
        try
        {
            return await courseRepository.GetAsync(id);
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting course: " + e.Message);
        }
    }

    public async Task<IEnumerable<CourseModel>> GetAsync()
    {
        try
        {
            return await courseRepository.GetManyAsync();
        }
        catch (Exception e)
        {
            throw new UnknownException("Error getting courses: " + e.Message);
        }
    }
}