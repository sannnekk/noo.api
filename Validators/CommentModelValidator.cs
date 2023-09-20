using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class CommentModelValidator : AbstractValidator<CommentModel>
    {
        public CommentModelValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Slug).MaximumLength(384).NotEmpty();
            RuleFor(c => c.Score).GreaterThan(0);
        }
    }
}
