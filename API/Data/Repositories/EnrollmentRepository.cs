using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly LearningPlatformDbContext _dbContext;

    public EnrollmentRepository(LearningPlatformDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Enrollment> EnrollToCourseAsync(Enrollment enrollment)
    {
        await _dbContext.Enrollments.AddAsync(enrollment);
        return enrollment;
    }

    public async Task<Enrollment?> GetEnrollmentAsync(Guid userId, Guid courseId)
    {
        return await _dbContext.Enrollments.AsNoTracking().SingleOrDefaultAsync(e => e.UserId == userId && e.CourseId == courseId);
    }

    public async Task UnenrollToCourseAsync(Enrollment enrollment)
    {
        _dbContext.Enrollments.Remove(enrollment);
        await Task.CompletedTask;
    }

    public async Task<List<Course>> GetEnrolledCoursesAsync(Guid userId)
    {
        return await _dbContext.Enrollments.AsNoTracking().Where(e => e.UserId == userId).Include(e => e.Course).ThenInclude(c => c.Lessons).ThenInclude(l => l.Progresses)
            .Select(e => e.Course).ToListAsync();
    }

    public async Task<bool> IsEnrollmentExists(Guid userId, Guid courseId)
    {
        return await _dbContext.Enrollments.AsNoTracking().AnyAsync(e => e.UserId == userId && e.CourseId == courseId);
    }

    public async Task<bool> IsEnrollmentExistsByLessonId(Guid userId, Guid lessonId)
    {
        return await _dbContext.Enrollments.AsNoTracking().AnyAsync(e => e.UserId == userId && e.Course.Lessons.Any(l => l.Id == lessonId));
    }
}
