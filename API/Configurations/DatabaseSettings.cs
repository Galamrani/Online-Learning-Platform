namespace OnlineLearning.API;

public class DatabaseSettings
{
    public string Provider { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool TrustServerCertificate { get; set; }

    public string GetConnectionString()
    {
        return $"Server={Host},{Port};Database={DatabaseName};User Id={User};Password={Password};TrustServerCertificate={TrustServerCertificate}";
    }
}
