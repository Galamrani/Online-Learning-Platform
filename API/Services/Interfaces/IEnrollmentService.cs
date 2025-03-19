namespace OnlineLearning.API;

public interface IEnrollmentService
{
    Task<List<CourseDto>> GetEnrolledCoursesAsync(Guid userId);
    Task<bool> EnrollToCourseAsync(Guid userId, Guid courseId);
    Task<bool> UnenrollToCourseAsync(Guid userId, Guid courseId);
}