using AutoMapper;

namespace OnlineLearning.API;

public class EnrollmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<List<CourseDto>> GetEnrolledCoursesAsync(Guid userId) //
    {
        List<Course> courses = await _unitOfWork.Enrollments.GetEnrolledCoursesAsync(userId);
        return _mapper.Map<List<CourseDto>>(courses);
    }

    public async Task<EnrollmentDto?> EnrollToCourseAsync(Guid userId, Guid courseId) //
    {
        if (await _unitOfWork.Enrollments.IsEnrollmentExists(userId, courseId)) return null;

        Enrollment enrollment = new Enrollment() { UserId = userId, CourseId = courseId };

        Enrollment dbEnrollment = await _unitOfWork.Enrollments.EnrollToCourseAsync(enrollment);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<EnrollmentDto>(dbEnrollment);
    }

    public async Task<bool> UnenrollToCourseAsync(Guid userId, Guid courseId) //
    {
        Enrollment? enrollment = await _unitOfWork.Enrollments.GetEnrollmentAsync(userId, courseId);
        if (enrollment == null) return false;


        await _unitOfWork.Enrollments.UnenrollToCourseAsync(enrollment);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

}
