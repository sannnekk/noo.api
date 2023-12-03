using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment;

[RegisterClassAsScoped]

public class CommentValidator : BaseRequestValidator<CommentModel>
{
    public CommentValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.CreatedAt).NotEmpty();
        RuleFor(m => m.UpdatedAt).NotEmpty();
        RuleFor(m => m.Slug).MaximumLength(512).NotNull();
        RuleFor(m => m.Content).NotNull();
        RuleFor(m => m.TaskId).NotEmpty();
        RuleFor(m => m.AssignedWorkId).NotEmpty();
    }
}
