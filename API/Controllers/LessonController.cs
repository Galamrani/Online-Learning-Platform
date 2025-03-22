using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.API;

[Route("api/lessons")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [Authorize]
    [HttpPost("progress/{lessonId}")]
    public async Task<IActionResult> AddProgress(Guid lessonId, [FromBody] ProgressDto progressDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        progressDto.LessonId = lessonId;

        if (!await _lessonService.AddProgressAsync(progressDto))
        {
            return NotFound(new LessonNoFoundError(progressDto.LessonId));
        }

        return Created(string.Empty, null);
    }

    [Authorize]
    [HttpPost("{courseId}")]
    public async Task<IActionResult> AddLesson(Guid courseId, [FromBody] LessonDto lessonDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        lessonDto.CourseId = courseId;
        LessonDto? lesson = await _lessonService.AddLessonAsync(UserIdHelper.GetUserId(HttpContext), lessonDto);

        if (lesson == null) return NotFound(new CourseNoFoundError(lessonDto.CourseId));

        return Created(string.Empty, lesson);

    }

    [Authorize]
    [HttpDelete("{lessonId}")]
    public async Task<IActionResult> DeleteLesson(Guid lessonId)
    {
        bool isDeleted = await _lessonService.DeleteLessonAsync(UserIdHelper.GetUserId(HttpContext), lessonId);

        if (isDeleted) return NoContent();

        return NotFound(new LessonNoFoundError(lessonId));
    }

    [Authorize]
    [HttpPatch("{lessonId}")]
    public async Task<IActionResult> UpdateLesson(Guid lessonId, [FromBody] LessonDto lessonDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        lessonDto.Id = lessonId;
        LessonDto? lesson = await _lessonService.UpdateLessonAsync(UserIdHelper.GetUserId(HttpContext), lessonDto);

        if (lesson == null) return NotFound(new LessonNoFoundError(lessonId));

        return Ok(lesson);
    }

}

