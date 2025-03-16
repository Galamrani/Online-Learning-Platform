using AutoMapper;

namespace OnlineLearning.API;

public class LessonService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<LessonDto?> AddLessonAsync(Guid userId, LessonDto lessonDto) //
    {
        if (!await _unitOfWork.Courses.IsCourseExistsAsync(lessonDto.CourseId)) return null;

        if (!await _unitOfWork.Courses.IsCreatorByCourseIdAsync(userId, lessonDto.CourseId)) throw new UnauthorizedAccessException("You are not allowed to add lesson to this course, your not the creator.");

        Lesson lesson = _mapper.Map<Lesson>(lessonDto);
        Lesson dbLesson = await _unitOfWork.Lessons.AddLessonAsync(lesson);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<LessonDto>(dbLesson);
    }

    public async Task<ProgressDto?> AddProgressAsync(ProgressDto progressDto) //
    {
        if (!await _unitOfWork.Lessons.IsLessonExistsAsync(progressDto.LessonId)) return null;

        if (!await _unitOfWork.Enrollments.IsEnrollmentExistsByLessonId(progressDto.UserId, progressDto.LessonId)) throw new UnauthorizedAccessException("You are not allowed to add progress to this lesson, your not the enrolled to it.");

        Progress progress = _mapper.Map<Progress>(progressDto);
        Progress dbProgress = await _unitOfWork.Progresses.AddProgressAsync(progress);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<ProgressDto>(dbProgress);
    }

    public async Task<bool> DeleteLessonAsync(Guid userId, Guid lessonId) //
    {
        Lesson? lesson = await _unitOfWork.Lessons.GetLessonAsync(lessonId);
        if (lesson == null) return false;

        if (!await _unitOfWork.Lessons.IsCreatorByLessonIdAsync(userId, lesson.Id)) throw new UnauthorizedAccessException("You are not allowed to delete this lesson, your not the creator of the course.");

        await _unitOfWork.Lessons.DeleteLessonAsync(lesson);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<LessonDto?> UpdateLessonAsync(Guid userId, LessonDto lessonDto) //
    {
        Lesson? oldLesson = await _unitOfWork.Lessons.GetLessonAsync(lessonDto.Id);
        if (oldLesson == null) return null;

        if (!await _unitOfWork.Lessons.IsCreatorByLessonIdAsync(userId, oldLesson.Id)) throw new UnauthorizedAccessException("You are not allowed to update this lesson, your not the creator of the course.");

        Lesson lesson = _mapper.Map<Lesson>(lessonDto);
        Lesson newLesson = await _unitOfWork.Lessons.UpdateLessonAsync(lesson, oldLesson);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<LessonDto>(newLesson);
    }

}
