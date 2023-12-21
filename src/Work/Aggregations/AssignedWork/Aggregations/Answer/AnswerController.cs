using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.DataAbstraction;
using noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.Services;
using noo.api.Core.Request;
using noo.api.Core.Security.Permissions;
using FluentValidation;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer;

[ApiController]
[Route("/work/assigned-work/answer")]
public class AnswerController : ControllerBase
{
    private readonly Core.Log.ILogger logger;
    private readonly AnswerValidator validator;
    private readonly IAnswerService answerService;

    private readonly IRequestContext requestContext;

    public AnswerController(Core.Log.ILogger logger, AnswerValidator validator, IAnswerService answerService, IRequestContext requestContext)
    {
        this.logger = logger;
        this.validator = validator;
        this.answerService = answerService;
        this.requestContext = requestContext;
    }

    [Authorize]
    [HttpPost]    
    public async Task<IActionResult> CreateAnswer(AnswerModel answer)
    {
        try
        {
            this.validator.ValidateAndThrow(answer);
            this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);
            await this.answerService.CreateAsync(answer);
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
    public async Task<IActionResult> UpdateAnswer(AnswerModel answer)
    {
        try
        {
            this.validator.ValidateAndThrow(answer);
            this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);
            await this.answerService.UpdateAsync(answer);
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
    public async Task<IActionResult> DeleteAnswer(Ulid id)
    {
        try
        {
            this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);
            await this.answerService.DeleteAsync(id);
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
    public async Task<IActionResult> GetAnswer(Ulid id)
    {
        try
        {
            // requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);        // TODO: Add permission to check works
            var answer = await this.answerService.GetAsync(id);
            return Ok(answer);
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAnswers()
    {
        try
        {
            // this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);   // TODO: Add permission to check works
            var answers = await this.answerService.GetAsync();
            return Ok(answers);
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }
}