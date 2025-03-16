using AutoMapper;

namespace OnlineLearning.API;

public class CourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<List<CourseDto>> GetCoursesAsync()
    {
        List<Course> courses = await _unitOfWork.Courses.GetCoursesAsync();
        return _mapper.Map<List<CourseDto>>(courses);
    }

    public async Task<CourseDto> GetFullCourseAsync(Guid userId, Guid courseId)
    {
        Course? course = await _unitOfWork.Courses.GetFullCourseAsync(userId, courseId);
        return _mapper.Map<CourseDto>(course);
    }

    public async Task<CourseDto> GetCourseAsync(Guid courseId)
    {
        Course? courses = await _unitOfWork.Courses.GetCourseAsync(courseId);
        return _mapper.Map<CourseDto>(courses);
    }

    public async Task<List<CourseDto>> GetUserCreatedCoursesAsync(Guid userId)
    {
        List<Course> courses = await _unitOfWork.Courses.GetUserCreatedCoursesAsync(userId);
        return _mapper.Map<List<CourseDto>>(courses);
    }

    public async Task<CourseDto> AddCourseAsync(CourseDto courseDto)
    {
        Course course = _mapper.Map<Course>(courseDto);
        Course dbCourses = await _unitOfWork.Courses.AddCourseAsync(course);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<CourseDto>(dbCourses);
    }

    public async Task<bool> DeleteCourseAsync(Guid userId, Guid courseId)
    {
        Course? course = await _unitOfWork.Courses.GetCourseAsync(courseId);
        if (course == null) return false;

        if (!await _unitOfWork.Courses.IsCreatorByCourseIdAsync(userId, courseId)) throw new UnauthorizedAccessException("You are not allowed to delete this course, your not the creator.");

        await _unitOfWork.Courses.DeleteCourseAsync(course);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<CourseDto?> UpdateCourseAsync(Guid userId, CourseDto courseDto)
    {
        Course? oldCourse = await _unitOfWork.Courses.GetCourseAsync(courseDto.Id);
        if (oldCourse == null) return null;

        if (userId != courseDto.CreatorId) throw new UnauthorizedAccessException("You are not allowed to update this course, your not the creator.");

        Course course = _mapper.Map<Course>(courseDto);
        Course newCourse = await _unitOfWork.Courses.UpdateCourseAsync(course, oldCourse);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<CourseDto>(newCourse);
    }
}
