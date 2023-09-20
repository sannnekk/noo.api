using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class SubjectModelValidator : AbstractValidator<SubjectModel>
    {
        public SubjectModelValidator()
        {
            RuleFor(s => s.Id).NotEmpty();
            RuleFor(s => s.Slug).MaximumLength(384).NotEmpty();
            RuleFor(s => s.Name).MaximumLength(255).NotEmpty();
        }
    }
}
