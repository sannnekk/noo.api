using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class TaskModelValidator : AbstractValidator<TaskModel>
    {
        public TaskModelValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Slug).MaximumLength(384).NotEmpty();
            RuleFor(t => t.WorkId).NotEmpty();
            RuleFor(t => t.Name).MaximumLength(255);
        }
    }
}
