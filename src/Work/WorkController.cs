using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noo.api.Work.DataAbstraction;
using noo.api.Work.Services;
using noo.api.Core.Request;
using noo.api.Core.Security.Permissions;

namespace noo.api.Work;

[ApiController]
[Route("course")]
public class WorkController : ControllerBase
{
    private readonly Core.Log.ILogger logger;
    private readonly WorkValidator validator;
    private readonly IWorkService workService;

    private readonly IRequestContext requestContext;

    public WorkController(Core.Log.ILogger logger, WorkValidator validator, IWorkService workService, IRequestContext requestContext)
    {
        this.logger = logger;
        this.validator = validator;
        this.workService = workService;
        this.requestContext = requestContext;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateWork(WorkModel work)
    {
        var validated = this.validator.Validate(work);
        this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);

        try
        {
            if (!validated.IsValid)
                return BadRequest(validated.Errors);
            await this.workService.CreateAsync(work);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateWork(WorkModel work)
    {
        var validated = this.validator.Validate(work);
        this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);

        try
        {
            if (!validated.IsValid)
                return BadRequest(validated.Errors);
            
            await this.workService.UpdateAsync(work);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWork(Ulid id)
    {
        this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);
        try
        {
            await this.workService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWork(Ulid id)
    {
        this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks); // ? Get work for teacher??
        try
        {
            var work = await this.workService.GetAsync(id);
            return Ok(work);
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetWorks()
    {
        this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks); // ? Get work for teacher??
        try
        {
            var works = await this.workService.GetAsync();
            return Ok(works);
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }
}
 