using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class LessonService : ILessonService
{
    private readonly LearningPlatformDbContext _dbContext;
    private readonly IMapper _mapper;

    public LessonService(LearningPlatformDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<LessonDto?> AddLessonAsync(Guid userId, LessonDto lessonDto)
    {
        if (!await IsUserCourseCreatorAsync(userId, lessonDto.CourseId))
        {
            throw new UnauthorizedAccessException("You are not allowed to add lesson to this course, your not the creator.");
        }

        Lesson lesson = _mapper.Map<Lesson>(lessonDto);
        await _dbContext.Lessons.AddAsync(lesson);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<LessonDto>(lesson);
    }

    public async Task<bool> AddProgressAsync(ProgressDto progressDto)
    {
        if (!await IsUserEnrolledToCourseByLessonIdAsync(progressDto.UserId, progressDto.LessonId))
        {
            throw new UnauthorizedAccessException("You are not allowed to add progress to this lesson, your not the enrolled to it.");
        }

        Progress progress = _mapper.Map<Progress>(progressDto);
        await _dbContext.Progresses.AddAsync(progress);

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteLessonAsync(Guid userId, Guid lessonId)
    {
        Lesson? lesson = await GetLessonByIdAsync(lessonId);
        if (lesson == null) return false;

        if (!await IsUserCourseCreatorAsync(userId, lesson.CourseId))
        {
            throw new UnauthorizedAccessException("You are not allowed to delete this lesson, your not the creator of the course.");
        }

        _dbContext.Lessons.Remove(lesson);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<LessonDto?> UpdateLessonAsync(Guid userId, LessonDto lessonDto)
    {
        Lesson? lesson = await GetLessonByIdAsync(lessonDto.Id);
        if (lesson == null) return null;

        if (!await IsUserCourseCreatorAsync(userId, lesson.CourseId))
        {
            throw new UnauthorizedAccessException("You are not allowed to delete this lesson, your not the creator of the course.");
        }

        _mapper.Map(lessonDto, lesson);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<LessonDto>(lesson);
    }

    //

    private async Task<Lesson?> GetLessonByIdAsync(Guid lessonId)
    {
        return await _dbContext.Lessons
            .FirstOrDefaultAsync(l => l.Id == lessonId);
    }

    private async Task<bool> IsUserCourseCreatorAsync(Guid userId, Guid courseId)
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .AnyAsync(c => c.Id == courseId && c.CreatorId == userId);
    }

    private async Task<bool> IsUserEnrolledToCourseByLessonIdAsync(Guid userId, Guid lessonId)
    {
        return await _dbContext.Enrollments
            .AsNoTracking()
            .AnyAsync(e => e.UserId == userId && e.Course.Lessons.Any(l => l.Id == lessonId));
    }

}
