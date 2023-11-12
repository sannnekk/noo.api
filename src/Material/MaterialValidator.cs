using AutoDependencyRegistration.Attributes;
using FluentValidation;
using noo.api.Material.DataAbstraction;

namespace noo.api.Material;

[RegisterClassAsScoped]
public class MaterialValidator : AbstractValidator<MaterialModel>
{
    public MaterialValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.Name).MaximumLength(255).NotNull();
    }
}