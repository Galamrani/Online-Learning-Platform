namespace OnlineLearning.API;

public interface ICourseRepository
{
    public Task<List<Course>> GetCoursesAsync();
    public Task<Course?> GetFullCourseAsync(Guid userId, Guid courseId);
    public Task<List<Course>> GetUserCreatedCoursesAsync(Guid userId);
    public Task<Course?> GetCourseAsync(Guid courseId);
    public Task<Course> AddCourseAsync(Course course);
    public Task DeleteCourseAsync(Course course);
    public Task DeleteCoursesAsync(List<Course> course);
    public Task<Course> UpdateCourseAsync(Course course, Course oldCourse);
    public Task<bool> IsCourseExistsAsync(Guid courseId);
    public Task<bool> IsCreatorByCourseIdAsync(Guid userId, Guid courseId);
}
