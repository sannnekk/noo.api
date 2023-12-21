using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Statistic.DataAbstraction;
using noo.api.Core.Security.Permissions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace noo.api.Statistic;

[RegisterClassAsScoped]
public class StatisticWorksValidator : BaseRequestValidator<StatisticRequestBody>
{
    public StatisticWorksValidator()
    {
        RuleFor(m => m.Type)
            .NotEmpty()
            .Must(type => type == "average" || type == "max")
            .WithMessage("Type error.");
        RuleFor(m => m.StartDate).NotEmpty();
        RuleFor(m => m.Type)
            .Must(accuracy => accuracy == "week" || accuracy == "month")
            .WithMessage("Accuracy must be either 'week' or 'month'.");
        RuleFor(m => m.Users)
            .NotEmpty()
            .WithMessage("Users must contain at least one user.");
    }
}
