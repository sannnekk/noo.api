using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Course.DataAbstraction;

namespace noo.api.Course;

[RegisterClassAsScoped]
public class CourseValidator : BaseRequestValidator<CourseModel>
{
    public CourseValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.Name).MaximumLength(255).NotNull();
    }
}