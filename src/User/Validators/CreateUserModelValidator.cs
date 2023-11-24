using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Core.Request;
using noo.api.User.DataAbstraction;

namespace noo.api.User.Validators
{
    [RegisterClassAsScoped]
    public class CreateUserModelValidator : BaseRequestValidator<CreateUserModelDTO>
    {
        public CreateUserModelValidator()
        {
            RuleFor(e => e.Username).MaximumLength(32).NotEmpty();
            RuleFor(e => e.Email).EmailAddress().NotEmpty();
            RuleFor(e => e.Password).MinimumLength(8).MaximumLength(32).NotEmpty();
        }
    }
}
