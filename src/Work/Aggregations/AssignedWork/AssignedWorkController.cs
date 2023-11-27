using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noo.api.Work.Aggregations.AssignedWork.DataAbstraction;
using noo.api.Work.Aggregations.AssignedWork.Services;
using noo.api.Core.Request;
using noo.api.Core.Security.Permissions;
using FluentValidation;

namespace noo.api.Work.Aggregations.AssignedWork;

[ApiController]
[Route("/work/assigned-work")]
public class AssignedWorkController : ControllerBase
{
    private readonly Core.Log.ILogger logger;
    private readonly AssignedWorkValidator validator;
    private readonly IAssignedWorkService assignedWorkService;

    private readonly IRequestContext requestContext;

    public AssignedWorkController(Core.Log.ILogger logger, AssignedWorkValidator validator, IAssignedWorkService assignedWorkService, IRequestContext requestContext)
    {
        this.logger = logger;
        this.validator = validator;
        this.assignedWorkService = assignedWorkService;
        this.requestContext = requestContext;
    }

    [Authorize]
    [HttpPost]    
    public async Task<IActionResult> CreateAssignedWork(AssignedWorkModel assignedWork)
    {
        try
        {
            this.validator.ValidateAndThrow(assignedWork);
            this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);
            await this.assignedWorkService.CreateAsync(assignedWork);
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
    public async Task<IActionResult> UpdateAssignedWork(AssignedWorkModel assignedWork)
    {
        try
        {
            this.validator.ValidateAndThrow(assignedWork);
            this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);
            await this.assignedWorkService.UpdateAsync(assignedWork);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete]    
    public async Task<IActionResult> DeleteAssignedWork(Ulid id)
    {
        try
        {
            this.requestContext.PermissionResolver.HasPermission(Permissions.CreateWorks);
            await this.assignedWorkService.DeleteAsync(id);
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
    public async Task<IActionResult> GetAssignedWork(Ulid id)
    {
        try
        {
            this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);
            var assignedWork = await this.assignedWorkService.GetAsync(id);
            return Ok(assignedWork);
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAssignedWorks()
    {
        try
        {
            this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);
            var assignedWorks = await this.assignedWorkService.GetAsync();
            return Ok(assignedWorks);
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }
}