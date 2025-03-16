using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.API;

[ApiController]
public class RouteNotFoundController : ControllerBase
{
    [Route("{**path}")]
    public IActionResult RouteNotFound(string path)
    {
        string method = HttpContext.Request.Method;
        RouteNotFoundError error = new RouteNotFoundError(method, path);
        return NotFound(error); // 404
    }
}

