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
        Log.Information("Request: {Method} {Path} from {IP}",
             context.Request.Method,
             context.Request.Path,
             context.Connection.RemoteIpAddress);

        await _next(context);

        Log.Information("Response: {StatusCode} for {Method} {Path}",
            context.Response.StatusCode,
            context.Request.Method,
            context.Request.Path);
    }
}

