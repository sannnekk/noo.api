using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.DataAbstraction;
using noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.Services;
using noo.api.Core.Request;
using noo.api.Core.Security.Permissions;
using FluentValidation;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment;

[ApiController]
[Route("/work/assigned-work/comment")]
public class CommentController : ControllerBase
{
    private readonly Core.Log.ILogger logger;
    private readonly CommentValidator validator;
    private readonly ICommentService commentService;

    private readonly IRequestContext requestContext;

    public CommentController(Core.Log.ILogger logger, CommentValidator validator, ICommentService commentService, IRequestContext requestContext)
    {
        this.logger = logger;
        this.validator = validator;
        this.commentService = commentService;
        this.requestContext = requestContext;
    }

    [Authorize]
    [HttpPost]    
    public async Task<IActionResult> CreateComment(CommentModel comment)
    {
        try
        {
            this.validator.ValidateAndThrow(comment);
            this.requestContext.PermissionResolver.HasPermission(Permissions.CheckWorks);
            await this.commentService.CreateAsync(comment);
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
    public async Task<IActionResult> UpdateComment(CommentModel comment)
    {
        try
        {
            this.validator.ValidateAndThrow(comment);
            this.requestContext.PermissionResolver.HasPermission(Permissions.CheckWorks);
            await this.commentService.UpdateAsync(comment);
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
    public async Task<IActionResult> DeleteComment(Ulid id)
    {
        try
        {
            this.requestContext.PermissionResolver.HasPermission(Permissions.CheckWorks);
            await this.commentService.DeleteAsync(id);
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
    public async Task<IActionResult> GetComment(Ulid id)
    {
        try
        {
            this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);
            var comment = await this.commentService.GetAsync(id);
            return Ok(comment);
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetComments()
    {
        try
        {
            this.requestContext.PermissionResolver.HasPermission(Permissions.SolveWorks);
            var comments = await this.commentService.GetAsync();
            return Ok(comments);
        }
        catch (Exception e)
        {
            logger.Log(e);
            return BadRequest(e.Message);
        }
    }
}