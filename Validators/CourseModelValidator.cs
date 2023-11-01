using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class CourseModelValidator : AbstractValidator<CourseModel>
    {
        public CourseModelValidator()
        {
            RuleFor(c => c.Name).MaximumLength(255).NotEmpty();
        }
    }
}
