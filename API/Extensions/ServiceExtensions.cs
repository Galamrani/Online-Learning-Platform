namespace OnlineLearning.API;

public static class ServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddDbContext<LearningPlatformDbContext>();
        services.AddTransient<IJwtService, JwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
    }
}

