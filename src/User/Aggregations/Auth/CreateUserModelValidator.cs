using FluentValidation;
using noo.api.Auth.DataAbstraction;
using noo.api.Core.Request;

namespace noo.api.Auth
{
    public class CreateUserModelValidator : BaseRequestValidator<CreateUserModelDTO>
    {
        public CreateUserModelValidator()
        {
            RuleFor(e => e.Username).MaximumLength(32).NotEmpty();
            RuleFor(e => e.Email).MaximumLength(256).NotEmpty();
            RuleFor(e => e.Password).MinimumLength(8).MaximumLength(32).NotEmpty();
        }
    }
}
