using FluentValidation;

namespace OnlineLearning.API;

public class ProgressDtoValidator : AbstractValidator<ProgressDto>
{
    public ProgressDtoValidator()
    {
        // UserId is required (must be a valid GUID)
        RuleFor(lesson => lesson.UserId)
            .NotEmpty().WithMessage("UserId is required");

        // LessonId is required (must be a valid GUID)
        RuleFor(lesson => lesson.LessonId)
            .NotEmpty().WithMessage("LessonId is required");
    }

}
