using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Serilog;

namespace OnlineLearning.API;


// Enables EF Core CLI commands (e.g., migrations, updates) by manually creating the DbContext at design-time.
// Bypasses Program.cs and DI by loading DatabaseSettings from appsettings.json and configuring DbContextOptions directly.
public class LearningPlatformDbContextFactory : IDesignTimeDbContextFactory<LearningPlatformDbContext>
{
    public LearningPlatformDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        DatabaseSettings? dbSettings = config.GetSection("DatabaseSettings").Get<DatabaseSettings>();

        if (dbSettings == null)
        {
            Log.Warning("⚠️ Failed to load 'DatabaseSettings' from configuration. Ensure appsettings.json is properly configured.");
            throw new InvalidOperationException("Missing or invalid 'DatabaseSettings' configuration.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<LearningPlatformDbContext>();
        optionsBuilder.UseSqlServer(dbSettings.GetConnectionString());

        return new LearningPlatformDbContext(optionsBuilder.Options);
    }
}
