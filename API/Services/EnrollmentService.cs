using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class EnrollmentService : IEnrollmentService
{
    private readonly LearningPlatformDbContext _dbContext;
    private readonly IMapper _mapper;

    public EnrollmentService(LearningPlatformDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<CourseDto>> GetEnrolledCoursesAsync(Guid userId)
    {
        List<Course> courses = await _dbContext.Enrollments
            .Where(e => e.UserId == userId)
            .Include(e => e.Course)
            .ThenInclude(c => c.Lessons)
            .ThenInclude(l => l.Progresses)
            .AsNoTracking()
            .Select(e => e.Course)
            .ToListAsync();

        return _mapper.Map<List<CourseDto>>(courses);
    }

    public async Task<bool> EnrollToCourseAsync(Guid userId, Guid courseId)
    {
        if (await IsUserEnrolledAsync(userId, courseId))
        {
            return false;
        }

        Enrollment enrollment = new Enrollment() { UserId = userId, CourseId = courseId };

        await _dbContext.Enrollments.AddAsync(enrollment);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UnenrollToCourseAsync(Guid userId, Guid courseId)
    {
        Enrollment? enrollment = await GetEnrollmentAsync(userId, courseId);
        if (enrollment == null) return false;

        _dbContext.Enrollments.Remove(enrollment);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    //

    private async Task<bool> IsUserEnrolledAsync(Guid userId, Guid courseId)
    {
        return await _dbContext.Enrollments
            .AsNoTracking()
            .AnyAsync(e => e.UserId == userId && e.CourseId == courseId);
    }

    private async Task<Enrollment?> GetEnrollmentAsync(Guid userId, Guid courseId)
    {
        return await _dbContext.Enrollments
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.UserId == userId && e.CourseId == courseId);
    }
}
