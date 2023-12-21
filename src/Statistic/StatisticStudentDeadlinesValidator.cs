using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.Statistic.DataAbstraction;
using noo.api.Core.Security.Permissions;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace noo.api.Statistic;

[RegisterClassAsScoped]
public class StatisticStudentDeadlinesValidator : BaseRequestValidator<StatisticRequestBody>
{
    public StatisticStudentDeadlinesValidator()
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
            .Empty()
            .WithMessage("As a student, you can only get your own statistic.");
    }

}
