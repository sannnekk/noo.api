using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class MediaModelValidator : AbstractValidator<MediaModel>
    {
        public MediaModelValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.Slug).MaximumLength(384).NotEmpty();
        }
    }
}
