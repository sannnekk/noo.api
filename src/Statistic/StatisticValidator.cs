using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Statistic.DataAbstraction;
using noo.api.Core.Security.Permissions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace noo.api.Statistic;

[RegisterClassAsScoped]
public class StatisticValidator : BaseRequestValidator<StatisticRequestBody>
{
    public StatisticValidator()
    {
        RuleFor(m => m.Type)
            .NotEmpty()
            .Must(type => (isWork && (type == "average" || type == "max")) || (!isWork && (type == "failed" || type == "rate")))
            .WithMessage("Type error.");
        RuleFor(m => m.StartDate).NotEmpty();
        RuleFor(m => m.Type)
            .Must(accuracy => accuracy == "week" || accuracy == "month")
            .WithMessage("Accuracy must be either 'week' or 'month'.");
        RuleFor(m => m.Users)
            .NotEmpty()
            .When(m => !isStudent)
            .WithMessage("Users must contain at least one user.");
    }

    Boolean isStudent = true;
    Boolean isWork = true;

    public void ValidatorSetUp(Boolean isStudent, Boolean isWork)
    {
        this.isStudent = isStudent;
        this.isWork = isWork;
    }

}
