namespace OnlineLearning.API;

public interface ILessonRepository
{
    public Task<Lesson> AddLessonAsync(Lesson lesson);
    public Task<Lesson?> GetLessonAsync(Guid lessonId);
    public Task<bool> IsLessonExistsAsync(Guid lessonId);
    public Task DeleteLessonAsync(Lesson lesson);
    public Task<Lesson> UpdateLessonAsync(Lesson lesson, Lesson oldLesson);
    public Task<bool> IsCreatorByLessonIdAsync(Guid userId, Guid lessonId);
}
