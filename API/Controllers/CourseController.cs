using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.API;


[Route("api/courses")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly CourseService _courseService;
    private readonly EnrollmentService _enrollmentService;

    public CourseController(CourseService courseService, EnrollmentService enrollmentService)
    {
        _courseService = courseService;
        _enrollmentService = enrollmentService;
    }

    [Authorize]
    [HttpGet("full-course/{courseId}")]
    public async Task<IActionResult> GetFullCourse([FromRoute] Guid courseId)
    {
        // Retrieves a full course including its lessons and the current user's progress.

        Guid userId = UserIdHelper.GetUserId(HttpContext);
        CourseDto? course = await _courseService.GetFullCourseAsync(userId, courseId);
        if (course == null) return NotFound(new CourseNoFoundError(courseId));
        return Ok(course);
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetBasicCourse([FromRoute] Guid courseId)
    {
        // Retrieves a course with its lessons, but without user-specific progress data.

        CourseDto? course = await _courseService.GetCourseAsync(courseId);
        if (course == null) return NotFound(new CourseNoFoundError(courseId));
        return Ok(course);
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        // Retrieves all available courses, each containing only lesson data.

        return Ok(await _courseService.GetCoursesAsync());
    }

    [Authorize]
    [HttpGet("student/my-courses")]
    public async Task<IActionResult> GetUserEnrolledCourses()
    {
        // Retrieves courses that the current user is enrolled in, including its lessons and the current user's progress.

        Guid userId = UserIdHelper.GetUserId(HttpContext);
        return Ok(await _enrollmentService.GetEnrolledCoursesAsync(userId));
    }

    [Authorize]
    [HttpGet("instructor/my-courses")]
    public async Task<IActionResult> GetUserCreatedCourses()
    {
        // Retrieves courses that the current user has created, with lesson details.

        Guid userId = UserIdHelper.GetUserId(HttpContext);
        return Ok(await _courseService.GetUserCreatedCoursesAsync(userId));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] CourseDto courseDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        Guid userId = UserIdHelper.GetUserId(HttpContext);
        courseDto.CreatorId = userId;
        CourseDto course = await _courseService.AddCourseAsync(courseDto);
        return CreatedAtAction(nameof(GetBasicCourse), new { courseId = course.Id }, course);
    }

    [Authorize]
    [HttpDelete("{courseId}")]
    public async Task<IActionResult> DeleteCourse([FromRoute] Guid courseId)
    {
        Guid userId = UserIdHelper.GetUserId(HttpContext);
        bool isDeleted = await _courseService.DeleteCourseAsync(userId, courseId);
        if (isDeleted) return NoContent();
        return NotFound(new CourseNoFoundError(courseId));
    }

    [Authorize]
    [HttpPatch("{courseId}")]
    public async Task<IActionResult> UpdateCourse([FromRoute] Guid courseId, [FromBody] CourseDto courseDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        courseDto.Id = courseId;
        Guid userId = UserIdHelper.GetUserId(HttpContext);
        CourseDto? course = await _courseService.UpdateCourseAsync(userId, courseDto);

        if (course == null) return NotFound(new CourseNoFoundError(courseId));
        return Ok(course);
    }

    [Authorize]
    [HttpPost("enroll/{courseId}")]
    public async Task<IActionResult> EnrollToCourse([FromRoute] Guid courseId)
    {
        Guid userId = UserIdHelper.GetUserId(HttpContext);
        EnrollmentDto? enrollment = await _enrollmentService.EnrollToCourseAsync(userId, courseId);

        if (enrollment == null) return BadRequest(new EnrollmentExistsError(userId, courseId));

        CourseDto? course = await _courseService.GetCourseAsync(courseId);
        if (course == null) return NotFound(new CourseNoFoundError(courseId));

        return CreatedAtAction(nameof(GetBasicCourse), new { courseId = course.Id }, course);
    }

    [Authorize]
    [HttpDelete("unenroll/{courseId}")]
    public async Task<IActionResult> UnenrollToCourse([FromRoute] Guid courseId)
    {
        Guid userId = UserIdHelper.GetUserId(HttpContext);
        bool isUnenrolled = await _enrollmentService.UnenrollToCourseAsync(userId, courseId);
        if (isUnenrolled) return NoContent();
        return NotFound(new EnrollmentNoFoundError(userId, courseId));
    }
}
