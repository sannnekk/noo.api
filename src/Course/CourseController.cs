using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noo.api.Course.DataAbstraction;
using noo.api.Course.Services;

namespace noo.api.Course;

[ApiController]
[Route("course")]
public class CourseController : ControllerBase
{
    private readonly Core.Log.ILogger logger;
    private readonly CourseValidator validator;
    private readonly ICourseService courseService;

    public CourseController(Core.Log.ILogger logger, CourseValidator validator, ICourseService courseService)
    {
        this.logger = logger;
        this.validator = validator;
        this.courseService = courseService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateMaterial(CourseModel material)
    {
        try
        {
            // TODO: create material
            await Task.Delay(1); // To make the compiler happy
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetMaterials()
    {
        try
        {
            return Ok(await this.courseService.GetAsync());
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

}