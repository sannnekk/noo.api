using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(u => u.Id).NotEmpty();           
            RuleFor(u => u.Name).MaximumLength(256);
        }
    }
}
