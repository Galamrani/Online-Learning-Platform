using System.Security.Claims;

namespace OnlineLearning.API
{
    public static class UserIdHelper
    {
        public static Guid GetUserId(HttpContext context)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(userId, out var parsedUserId) ? parsedUserId : Guid.Empty;
        }
    }
}
