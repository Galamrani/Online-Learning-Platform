namespace OnlineLearning.API;

/// <summary>
/// Represents the Unit of Work pattern to manage database transactions 
/// and ensure consistency across multiple repositories.
/// </summary>

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    ICourseRepository Courses { get; }
    ILessonRepository Lessons { get; }
    IProgressRepository Progresses { get; }
    IEnrollmentRepository Enrollments { get; }

    // Saves all pending changes to the database.
    Task<int> SaveChangesAsync();
}

