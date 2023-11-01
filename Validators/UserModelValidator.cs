using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.Slug).MaximumLength(384).NotEmpty();
            RuleFor(u => u.Name).MaximumLength(255);
            RuleFor(u => u.PasswordHash).NotEmpty();           
            RuleFor(u => u.TelegramId).MaximumLength(32);
            RuleFor(u => u.Forbidden).InclusiveBetween(0, (int)Math.Pow(2, 14));
            RuleFor(u => u.isBlocked).NotEmpty();
        }
    }
}
