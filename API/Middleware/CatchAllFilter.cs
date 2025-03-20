using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace OnlineLearning.API;

/// <summary>
/// Global exception filter to handle unauthorized access (403) and internal server errors (500).
/// Logs all errors using Serilog, including request details for debugging.
/// </summary>

public class CatchAllFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string httpMethod = context.HttpContext.Request.Method;
        string path = context.HttpContext.Request.Path;
        string user = context.HttpContext.User?.Identity?.Name ?? "Anonymous";

        if (context.Exception is UnauthorizedAccessException unauthorizedEx)
        {
            Log.Warning("Unauthorized access: {User}, {Method} {Path}", user, httpMethod, path);

            context.Result = new JsonResult(new UnauthorizedError(unauthorizedEx.Message))
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
        else
        {
            Log.Error(context.Exception, "Error: {User}, {Method} {Path}", user, httpMethod, path);

            string errorMessage = GetInnerMessage(context.Exception);

            context.Result = new JsonResult(new InternalServerError(errorMessage))
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    private string GetInnerMessage(Exception ex)
    {
        if (ex == null) return "";
        if (ex.InnerException == null) return ex.Message;
        return GetInnerMessage(ex.InnerException);
    }
}