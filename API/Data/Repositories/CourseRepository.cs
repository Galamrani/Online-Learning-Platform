using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class CourseRepository : ICourseRepository
{
    private readonly LearningPlatformDbContext _dbContext;

    public CourseRepository(LearningPlatformDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _dbContext.Courses.AsNoTracking().Include(c => c.Lessons).ToListAsync();
    }

    public async Task<Course> AddCourseAsync(Course course)
    {
        await _dbContext.Courses.AddAsync(course);
        return course;
    }

    public async Task<Course?> GetCourseAsync(Guid courseId)
    {
        return await _dbContext.Courses.Include(c => c.Lessons).FirstOrDefaultAsync(c => c.Id == courseId);
    }

    public async Task DeleteCourseAsync(Course course)
    {
        _dbContext.Courses.Remove(course);
        await Task.CompletedTask;
    }

    public async Task DeleteCoursesAsync(List<Course> courses)
    {
        _dbContext.Courses.RemoveRange(courses);
        await Task.CompletedTask;
    }

    public Task<Course> UpdateCourseAsync(Course course, Course oldCourse)
    {
        _dbContext.Entry(oldCourse).CurrentValues.SetValues(course);
        return Task.FromResult(oldCourse);
    }

    public async Task<List<Course>> GetUserCreatedCoursesAsync(Guid userId)
    {
        return await _dbContext.Courses.AsNoTracking().Where(c => c.CreatorId == userId).Include(c => c.Lessons).ToListAsync();
    }

    public async Task<Course?> GetFullCourseAsync(Guid userId, Guid courseId)
    {
        return await _dbContext.Courses.AsNoTracking().Where(c => c.Id == courseId)
            .Include(c => c.Lessons)
            .ThenInclude(l => l.Progresses.Where(p => p.UserId == userId))
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsCourseExistsAsync(Guid courseId)
    {
        return await _dbContext.Courses.AsNoTracking().AnyAsync(c => c.Id == courseId);
    }

    public async Task<bool> IsCreatorByCourseIdAsync(Guid userId, Guid courseId)
    {
        return await _dbContext.Courses.AsNoTracking().AnyAsync(c => c.CreatorId == userId);
    }
}
