using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Work.Aggregations.AssignedWork.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork;

[RegisterClassAsScoped]

public class AssignedWorkValidator : BaseRequestValidator<AssignedWorkModel>
{
    public AssignedWorkValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.CreatedAt).NotEmpty();
        RuleFor(m => m.UpdatedAt).NotEmpty();
        RuleFor(m => m.Slug).MaximumLength(512).NotNull();
        RuleFor(m => m.StudentId).NotEmpty();
        RuleFor(m => m.WorkId).NotEmpty();
        RuleFor(m => m.SolveStatus).NotEmpty();
        RuleFor(m => m.CheckStatus).NotEmpty();
        RuleFor(m => m.SolveDeadlineAt).NotEmpty();
        RuleFor(m => m.CheckDeadlineAt).NotEmpty();
        RuleFor(m => m.MaxScore).NotEmpty();
    }
}
