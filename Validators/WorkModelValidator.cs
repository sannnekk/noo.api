using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class WorkModelValidator : AbstractValidator<WorkModel>
    {
        public WorkModelValidator()
        {
            RuleFor(w => w.Id).NotEmpty();               
            RuleFor(w => w.Name).MaximumLength(255).NotEmpty();
        }
    }
}
