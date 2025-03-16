namespace OnlineLearning.API;

public interface IEnrollmentRepository
{
    public Task<Enrollment> EnrollToCourseAsync(Enrollment enrollment);
    public Task UnenrollToCourseAsync(Enrollment enrollment);
    public Task<Enrollment?> GetEnrollmentAsync(Guid userId, Guid courseId);
    public Task<bool> IsEnrollmentExists(Guid userId, Guid courseId);
    public Task<bool> IsEnrollmentExistsByLessonId(Guid userId, Guid lessonId);
    public Task<List<Course>> GetEnrolledCoursesAsync(Guid userId);
}
