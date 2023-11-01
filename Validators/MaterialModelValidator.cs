using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class MaterialModelValidator : AbstractValidator<MaterialModel>
    {
        public MaterialModelValidator()
        {
            RuleFor(m => m.Id).NotEmpty();                   
            RuleFor(m => m.Name).MaximumLength(255).NotNull();
        }
    }
}
