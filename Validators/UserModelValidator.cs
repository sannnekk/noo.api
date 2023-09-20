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
            RuleFor(u => u.GoogleToken).MaximumLength(512);
            RuleFor(u => u.TelegramId).MaximumLength(32);
            RuleFor(u => u.isBlocked).NotEmpty();
        }
    }
}
