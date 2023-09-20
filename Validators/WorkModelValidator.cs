using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class WorkModelValidator : AbstractValidator<WorkModel>
    {
        public WorkModelValidator()
        {
            RuleFor(w => w.Id).NotEmpty();
            RuleFor(w => w.Slug).MaximumLength(384).NotEmpty();
            RuleFor(w => w.MaterialId).NotEmpty();
            RuleFor(w => w.Name).MaximumLength(255);
        }
    }
}
