using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.API;

[Route("api/lessons")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly LessonService _lessonService;


    public LessonController(LessonService lessonService)
    {
        _lessonService = lessonService;
    }

    //

    [Authorize]
    [HttpPost("add-progress/{lessonId}")]
    public async Task<IActionResult> AddProgress([FromRoute] Guid lessonId, [FromBody] ProgressDto progressDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        progressDto.LessonId = lessonId;
        ProgressDto? progress = await _lessonService.AddProgressAsync(progressDto);

        if (progress == null) return NotFound(new LessonNoFoundError(progressDto.LessonId));
        return Created(string.Empty, progress);
    }

    [Authorize]
    [HttpPost("{courseId}")]
    public async Task<IActionResult> AddLesson([FromRoute] Guid courseId, [FromBody] LessonDto lessonDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        lessonDto.CourseId = courseId;
        Guid userId = UserIdHelper.GetUserId(HttpContext);

        LessonDto? lesson = await _lessonService.AddLessonAsync(userId, lessonDto);
        if (lesson == null) return NotFound(new CourseNoFoundError(lessonDto.CourseId));
        return Created(string.Empty, lesson);

    }

    [Authorize]
    [HttpDelete("{lessonId}")]
    public async Task<IActionResult> DeleteLesson([FromRoute] Guid lessonId)
    {
        Guid userId = UserIdHelper.GetUserId(HttpContext);
        bool isDeleted = await _lessonService.DeleteLessonAsync(userId, lessonId);
        if (isDeleted) return NoContent();
        return NotFound(new LessonNoFoundError(lessonId));
    }

    [Authorize]
    [HttpPatch("{lessonId}")]
    public async Task<IActionResult> UpdateLesson([FromRoute] Guid lessonId, [FromBody] LessonDto lessonDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        lessonDto.Id = lessonId;
        Guid userId = UserIdHelper.GetUserId(HttpContext);
        LessonDto? lesson = await _lessonService.UpdateLessonAsync(userId, lessonDto);
        if (lesson == null) return NotFound(new LessonNoFoundError(lessonId));
        return Ok(lesson);
    }

}

