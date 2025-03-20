using FluentValidation;
using FluentValidation.AspNetCore;

namespace OnlineLearning.API;

public static class FluentValidationExtensions
{
    public static void AddFluentValidationServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CourseDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<RegisterDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<LessonDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<ProgressDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CredentialsDtoValidator>();
    }
}

