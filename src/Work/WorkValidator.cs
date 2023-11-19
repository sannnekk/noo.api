using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Work.DataAbstraction;

namespace noo.api.Work;

[RegisterClassAsScoped]
public class WorkValidator : BaseRequestValidator<WorkModel>
{
    public WorkValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.CreatedAt).NotEmpty();
        RuleFor(m => m.UpdatedAt).NotEmpty();
        RuleFor(m => m.Slug).MaximumLength(512).NotNull();
        RuleFor(m => m.Name).MaximumLength(255).NotNull();
        RuleFor(m => m.Deadline).NotEmpty();
    }
}
