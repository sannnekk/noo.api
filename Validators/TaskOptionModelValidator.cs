using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class TaskOptionModelValidator : AbstractValidator<TaskOptionModel>
    {
        public TaskOptionModelValidator()
        {
            RuleFor(t => t.Name).MaximumLength(512).NotEmpty();
        }
    }
}
