using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineLearning.API;

/// <summary>
/// Global exception filter to handle unauthorized access attempts.
/// This filter prevents the need for excessive try-catch blocks in controllers and services.
/// It ensures that if an authorized user attempts to perform actions on courses they did not create,
/// a proper 403 Forbidden response is returned.
/// </summary>

public class UnauthorizedActionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        // Check if the exception is an UnauthorizedAccessException
        if (context.Exception is UnauthorizedAccessException unauthorizedEx)
        {
            // Handle forbidden error (403)
            UnauthorizedError error = new UnauthorizedError(unauthorizedEx.Message);
            JsonResult result = new JsonResult(error);
            result.StatusCode = StatusCodes.Status403Forbidden;
            context.Result = result;
        }
    }

    // Recursively retrieves the innermost exception message.
    private string GetInnerMessage(Exception ex)
    {
        if (ex == null) return "";
        if (ex.InnerException == null) return ex.Message;
        return GetInnerMessage(ex.InnerException);
    }

}
