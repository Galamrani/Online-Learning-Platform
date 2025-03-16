using Microsoft.AspNetCore.Mvc.ModelBinding;
using Serilog;
using Serilog.Events;

namespace OnlineLearning.API;

public static class Extensions
{
    public static string GetAllErrors(this ModelStateDictionary modelState)
    {
        return string.Join("; ", modelState.Values
            .Where(v => v.Errors.Any())
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));
    }

    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.File("Logs/api.log", rollingInterval: RollingInterval.Minute, retainedFileCountLimit: 1)
            .MinimumLevel.Information()
            .CreateLogger();

        builder.Logging.AddSerilog(logger, dispose: true);
    }

}


