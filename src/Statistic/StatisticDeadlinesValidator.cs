using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Statistic.DataAbstraction;
using noo.api.Core.Security.Permissions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace noo.api.Statistic;

[RegisterClassAsScoped]
public class StatisticDeadlinesValidator : BaseRequestValidator<StatisticRequestBody>
{
    public StatisticDeadlinesValidator()
    {
        RuleFor(m => m.Type)
            .NotEmpty()
            .Must(type => type == "failed" || type == "rate")
            .WithMessage("Type must be either 'failed' or 'rate'.");
        RuleFor(m => m.StartDate).NotEmpty();
        RuleFor(m => m.Type)
            .Must(accuracy => accuracy == "week" || accuracy == "month")
            .WithMessage("Accuracy must be either 'week' or 'month'.");
        RuleFor(m => m.Users)
            .NotEmpty()
            .WithMessage("You are not a student, thus Users must contain at least one user.");
    }

}
