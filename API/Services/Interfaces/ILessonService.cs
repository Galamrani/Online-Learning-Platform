namespace OnlineLearning.API;

public interface ILessonService
{
    Task<LessonDto?> AddLessonAsync(Guid userId, LessonDto lessonDto);
    Task<LessonDto?> UpdateLessonAsync(Guid userId, LessonDto lessonDto);
    Task<bool> DeleteLessonAsync(Guid userId, Guid lessonId);
    Task<bool> AddProgressAsync(ProgressDto progressDto);
}