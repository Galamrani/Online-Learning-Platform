using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.API;

public static class ConfigurationExtensions
{
    public static void AddApplicationConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
        services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
    }
}
