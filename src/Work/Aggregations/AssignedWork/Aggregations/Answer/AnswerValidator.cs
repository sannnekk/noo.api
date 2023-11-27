using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer;

[RegisterClassAsScoped]

public class AnswerValidator : BaseRequestValidator<AnswerModel>
{
    public AnswerValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.CreatedAt).NotEmpty();
        RuleFor(m => m.UpdatedAt).NotEmpty();
        RuleFor(m => m.Slug).MaximumLength(512).NotNull();
        RuleFor(m => m.Content).NotNull();
        RuleFor(m => m.Word).MaximumLength(512).NotNull();
        RuleFor(m => m.AssignedWorkId).NotEmpty();
    }
}
