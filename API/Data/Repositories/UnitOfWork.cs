namespace OnlineLearning.API;

/// <summary>
/// Implements the Unit of Work pattern to manage repository interactions and database commits.
/// </summary>

public class UnitOfWork : IUnitOfWork
{
    private readonly LearningPlatformDbContext _context;

    public IUserRepository Users { get; }
    public ICourseRepository Courses { get; }
    public ILessonRepository Lessons { get; }
    public IProgressRepository Progresses { get; }
    public IEnrollmentRepository Enrollments { get; }

    // Initializes a new instance of the UnitOfWork class, injecting the database context and repositories.
    public UnitOfWork(LearningPlatformDbContext context, IUserRepository users, ICourseRepository courses,
        ILessonRepository lessons, IProgressRepository progresses, IEnrollmentRepository enrollments)
    {
        _context = context;
        Users = users;
        Courses = courses;
        Lessons = lessons;
        Progresses = progresses;
        Enrollments = enrollments;
    }

    // Commits all changes to the database.
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    // Releases database resources when the UnitOfWork is disposed.
    public void Dispose()
    {
        _context.Dispose();
    }
}
