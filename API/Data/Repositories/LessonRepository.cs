using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class LessonRepository : ILessonRepository
{
    private readonly LearningPlatformDbContext _dbContext;

    public LessonRepository(LearningPlatformDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Lesson> AddLessonAsync(Lesson lesson)
    {
        await _dbContext.Lessons.AddAsync(lesson);
        return lesson;
    }

    public async Task DeleteLessonAsync(Lesson lesson)
    {
        _dbContext.Lessons.Remove(lesson);
        await Task.CompletedTask;
    }

    public async Task<Lesson?> GetLessonAsync(Guid lessonId)
    {
        return await _dbContext.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId);
    }

    public async Task<bool> IsCreatorByLessonIdAsync(Guid userId, Guid lessonId)
    {
        return await _dbContext.Lessons.AsNoTracking().AnyAsync(l => l.Id == lessonId && l.Course.CreatorId == userId);
    }

    public async Task<bool> IsLessonExistsAsync(Guid lessonId)
    {
        return await _dbContext.Lessons.AsNoTracking().AnyAsync(l => l.Id == lessonId);
    }

    public Task<Lesson> UpdateLessonAsync(Lesson lesson, Lesson oldLesson)
    {
        _dbContext.Entry(oldLesson).CurrentValues.SetValues(lesson);
        return Task.FromResult(oldLesson);
    }
}
