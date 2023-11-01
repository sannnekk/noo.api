using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class AssignedWorkModelValidator : AbstractValidator<AssignedWorkModel>
    {
        public AssignedWorkModelValidator()
        {
            RuleFor(a => a.Score).GreaterThan(0);
            RuleFor(a => a.MaxScore).GreaterThan(0);
        }
    }
}
