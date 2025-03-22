using System.Security.Claims;

namespace OnlineLearning.API
{
    // Helper class to retrieve the user's ID from the HttpContext using claims.
    // - GetUserId: Extracts the user ID from the NameIdentifier claim.
    // - Returns a valid Guid if the ID is found and correctly formatted, otherwise returns Guid.Empty.
    public static class UserIdHelper
    {
        public static Guid GetUserId(HttpContext context)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(userId, out var parsedUserId) ? parsedUserId : Guid.Empty;
        }
    }
}
