using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class ChapterModelValidator : AbstractValidator<ChapterModel>
    {
        public ChapterModelValidator()
        {
            RuleFor(c => c.Name).MaximumLength(255).NotEmpty();
        }
    }
}
