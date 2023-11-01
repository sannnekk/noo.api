using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class ImageCommentModelValidator : AbstractValidator<ImageCommentModel>
    {
        public ImageCommentModelValidator()
        {
            RuleFor(i => i.X).GreaterThanOrEqualTo(0).NotEmpty();
            RuleFor(i => i.Y).GreaterThanOrEqualTo(0).NotEmpty();
            RuleFor(i => i.Width).GreaterThanOrEqualTo(0).NotEmpty();
            RuleFor(i => i.Height).GreaterThanOrEqualTo(0).NotEmpty();
        }
    }
}
