using FluentValidation;

namespace noo.api.Course.Aggregations.CourseChapter.DataAbstraction;

public class CourseChapterValidator : AbstractValidator<CourseChapterModel>
{
    public CourseChapterValidator()
    {
        RuleFor(m => m.Name)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(255);
    }
}