using Serilog;

/// <summary>
/// Middleware for logging incoming requests and outgoing responses.
/// This helps track API activity without adding redundant logging in controllers or services.
/// </summary>

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        Log.Information("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
        await _next(context);
        Log.Information("Response: {StatusCode}", context.Response.StatusCode);
    }
}

