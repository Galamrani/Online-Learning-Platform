using System.Security.Claims;

/// <summary>
/// Middleware for extracting the user ID from the authentication token in the request.
/// This allows other parts of the application to access the user ID without requiring 
/// additional code in controllers or services.
/// </summary>

namespace OnlineLearning.API
{
    public class UserIdMiddleware
    {
        private readonly RequestDelegate _next;

        public UserIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Extract user ID but do not modify response
            GetUserId(context);

            // Continue processing the request
            await _next(context);
        }

        public static Guid GetUserId(HttpContext context)
        {
            if (context.User.Identity is ClaimsIdentity identity && identity.IsAuthenticated)
            {
                var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
                {
                    return userId;
                }
            }
            return Guid.Empty;
        }
    }
}