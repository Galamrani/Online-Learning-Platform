namespace OnlineLearning.API;

public static class AppConfig
{
    public static bool IsDevelopment { get; private set; }
    public static bool IsProduction { get; private set; }
    public static string ConnectionString { get; private set; } = null!;
    public static string HostUrl { get; private set; } = null!;
    public static string JwtKey { get; private set; } = "GalAmrani_IsTheBest_NoDebate_IfYouDisagreeYouAreWrong_TrustMe_EncryptedWithLove_2025";
    public static int JwtExpireHours { get; private set; }

    public static void Config(IWebHostEnvironment env)
    {
        IsDevelopment = env.IsDevelopment();
        IsProduction = env.IsProduction();

        IConfigurationRoot settings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
            .Build();

        ConnectionString = settings.GetConnectionString("LearningPlatform")!;
        IsProduction = env.IsProduction();

        HostUrl = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")!; // "http://localhost:xxxx"
        JwtExpireHours = IsDevelopment ? 5 : 1;

    }
}
