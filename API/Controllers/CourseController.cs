using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.API;


[Route("api/courses")]
[ApiController]
public class CourseController(ICourseService _courseService, IEnrollmentService _enrollmentService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        // Retrieves all available courses, each containing only lesson data.

        return Ok(await _courseService.GetCoursesAsync());
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetBasicCourse(Guid courseId)
    {
        // Retrieves a course with its lessons, but without user-specific progress data.

        CourseDto? course = await _courseService.GetBasicCourseAsync(courseId);
        if (course == null) return NotFound(new CourseNoFoundError(courseId));
        return Ok(course);
    }

    [Authorize]
    [HttpGet("full-course/{courseId}")]
    public async Task<IActionResult> GetFullCourse(Guid courseId)
    {
        // Retrieves a full course including its lessons and the current user's progress.

        CourseDto? course = await _courseService.GetFullCourseAsync(UserIdHelper.GetUserId(HttpContext), courseId);

        if (course == null) return NotFound(new CourseNoFoundError(courseId));

        return Ok(course);
    }

    [Authorize]
    [HttpGet("student/my-courses")]
    public async Task<IActionResult> GetEnrolledCourses()
    {
        // Retrieves courses that the current user is enrolled to, including its lessons and the current user's progress.

        return Ok(await _enrollmentService.GetEnrolledCoursesAsync(UserIdHelper.GetUserId(HttpContext)));
    }

    [Authorize]
    [HttpGet("instructor/my-courses")]
    public async Task<IActionResult> GetCreatedCourses()
    {
        // Retrieves courses that the current user has created, with lesson details.

        return Ok(await _courseService.GetUserCreatedCoursesAsync(UserIdHelper.GetUserId(HttpContext)));
    }

    //

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] CourseDto courseDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        courseDto.CreatorId = UserIdHelper.GetUserId(HttpContext);

        CourseDto course = await _courseService.AddCourseAsync(courseDto);

        return CreatedAtAction(nameof(GetFullCourse), new { courseId = course.Id }, course);
    }

    [Authorize]
    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteCourse(Guid courseId)
    {
        bool isDeleted = await _courseService.DeleteCourseAsync(UserIdHelper.GetUserId(HttpContext), courseId);

        if (!isDeleted) return NotFound(new CourseNoFoundError(courseId));

        return NoContent();
    }

    [Authorize]
    [HttpPatch("{courseId}")]
    public async Task<IActionResult> UpdateCourse(Guid courseId, [FromBody] CourseDto courseDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        courseDto.Id = courseId;
        CourseDto? course = await _courseService.UpdateCourseAsync(UserIdHelper.GetUserId(HttpContext), courseDto);

        if (course == null) return NotFound(new CourseNoFoundError(courseId));

        return Ok(course);
    }


    [Authorize]
    [HttpPost("enroll/{courseId}")]
    public async Task<IActionResult> EnrollToCourse(Guid courseId)
    {
        CourseDto? course = await _courseService.GetBasicCourseAsync(courseId);
        if (course == null) return NotFound(new CourseNoFoundError(courseId));

        if (!await _enrollmentService.EnrollToCourseAsync(UserIdHelper.GetUserId(HttpContext), courseId))
        {
            return BadRequest(new EnrollmentExistsError(UserIdHelper.GetUserId(HttpContext), courseId));
        }

        return CreatedAtAction(nameof(GetFullCourse), new { courseId = course.Id }, course);
    }

    [Authorize]
    [HttpDelete("unenroll/{courseId}")]
    public async Task<IActionResult> UnenrollToCourse(Guid courseId)
    {
        bool isUnenrolled = await _enrollmentService.UnenrollToCourseAsync(UserIdHelper.GetUserId(HttpContext), courseId);
        if (isUnenrolled) return NoContent();

        return NotFound(new EnrollmentNoFoundError(UserIdHelper.GetUserId(HttpContext), courseId));
    }
}
