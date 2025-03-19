using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace OnlineLearning.API;

public class CourseService(LearningPlatformDbContext _dbContext, IMapper _mapper) : ICourseService
{

    public async Task<List<CourseDto>> GetCoursesAsync()
    {
        List<Course> courses = await _dbContext.Courses
            .Include(c => c.Lessons)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<List<CourseDto>>(courses);
    }

    public async Task<CourseDto> GetFullCourseAsync(Guid userId, Guid courseId)
    {
        Course? course = await _dbContext.Courses
            .Where(c => c.Id == courseId)
            .Include(c => c.Lessons)
            .ThenInclude(l => l.Progresses.Where(p => p.UserId == userId))
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return _mapper.Map<CourseDto>(course);
    }

    public async Task<CourseDto> GetBasicCourseAsync(Guid courseId)
    {
        Course? course = await _dbContext.Courses
            .Include(c => c.Lessons)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == courseId);

        return _mapper.Map<CourseDto>(course);
    }

    public async Task<List<CourseDto>> GetUserCreatedCoursesAsync(Guid userId)
    {
        List<Course> courses = await _dbContext.Courses
        .Where(c => c.CreatorId == userId)
        .Include(c => c.Lessons)
        .AsNoTracking()
        .ToListAsync();

        return _mapper.Map<List<CourseDto>>(courses);
    }

    public async Task<CourseDto> AddCourseAsync(CourseDto courseDto)
    {
        Course course = _mapper.Map<Course>(courseDto);
        await _dbContext.Courses.AddAsync(course);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<CourseDto>(course);
    }

    public async Task<bool> DeleteCourseAsync(Guid userId, Guid courseId)
    {
        Course? course = await GetCourseByIdAsync(courseId);
        if (course == null) return false;

        if (course.CreatorId != userId)
        {
            throw new UnauthorizedAccessException("You are not allowed to delete this course, your not the creator.");
        }

        _dbContext.Courses.Remove(course);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<CourseDto?> UpdateCourseAsync(Guid userId, CourseDto courseDto)
    {
        Course? course = await GetCourseByIdAsync(courseDto.Id);
        if (course == null) return null;

        if (course.CreatorId != userId)
        {
            throw new UnauthorizedAccessException("You are not allowed to update this course, your not the creator.");
        }

        _mapper.Map(courseDto, course);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<CourseDto>(course);
    }

    //

    private async Task<Course?> GetCourseByIdAsync(Guid courseId)
    {
        return await _dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == courseId);
    }
}
