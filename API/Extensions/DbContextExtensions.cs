using Microsoft.EntityFrameworkCore;
using Serilog;

namespace OnlineLearning.API;

public static class DbContextExtensions
{
    public static void AddDbContext(this WebApplicationBuilder builder)
    {
        DatabaseSettings? dbSettings = builder.Configuration
            .GetSection("DatabaseSettings")
            .Get<DatabaseSettings>();

        if (dbSettings == null)
        {
            Log.Warning("⚠️ Failed to load 'DatabaseSettings' from configuration. Ensure appsettings.json is properly configured.");
            throw new InvalidOperationException("Missing or invalid 'DatabaseSettings' configuration.");
        }

        builder.Services.AddDbContext<LearningPlatformDbContext>(options =>
            options.UseSqlServer(dbSettings.GetConnectionString()));
    }
}
