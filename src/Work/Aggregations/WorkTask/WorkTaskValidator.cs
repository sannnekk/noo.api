using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Work.Aggregations.WorkTask.DataAbstraction;

namespace noo.api.Work.Aggregations.WorkTask;

[RegisterClassAsScoped]

public class WorkTaskValidator : BaseRequestValidator<WorkTaskModel>
{
    public WorkTaskValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.CreatedAt).NotEmpty();
        RuleFor(m => m.UpdatedAt).NotEmpty();
        RuleFor(m => m.MaxPoints).NotEmpty();
        RuleFor(m => m.WorkId).NotEmpty();
    }
}
