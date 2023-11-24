using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.User.DataAbstraction;

namespace api.src.User.Validators
{
    [RegisterClassAsScoped]
    public class UserValidator : BaseRequestValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(e => e.Name).MaximumLength(256);
            RuleFor(e => e.Slug).MaximumLength(512);
            RuleFor(e => e.Username).MaximumLength(32).NotEmpty();
            RuleFor(e => e.Email).EmailAddress().NotEmpty();
            RuleFor(e => e.TelegramId).MaximumLength(64);
            RuleFor(e => e.PasswordHash).NotEmpty();
        }
    }
}
