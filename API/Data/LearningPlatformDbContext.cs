using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class LearningPlatformDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Progress> Progresses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User -> Course (Creator)
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Creator)
            .WithMany(u => u.CreatedCourses)
            .HasForeignKey(c => c.CreatorId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade deletion of courses when deleting a user

        // Course -> Lesson
        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade); // Deleting a course deletes its lessons

        // Course -> Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade); // Deleting a course deletes enrollments

        // User -> Enrollment
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.User)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Deleting a user deletes their enrollments

        // Lesson -> Progress
        modelBuilder.Entity<Progress>()
            .HasOne(p => p.Lesson)
            .WithMany(l => l.Progresses)
            .HasForeignKey(p => p.LessonId)
            .OnDelete(DeleteBehavior.Cascade); // Deleting a lesson deletes progress

        // User -> Progress
        modelBuilder.Entity<Progress>()
            .HasOne(p => p.User)
            .WithMany(u => u.Progresses)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Deleting a user deletes progress


        // Set default values for CreatedAt, EnrolledAt, and LastWatchedAt
        modelBuilder.Entity<Course>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Enrollment>()
            .Property(e => e.EnrolledAt)
            .HasDefaultValueSql("GETUTCDATE()");

        modelBuilder.Entity<Progress>()
            .Property(p => p.LastWatchedAt)
            .HasDefaultValueSql("GETUTCDATE()");


        base.OnModelCreating(modelBuilder);


        // Seed data
        SeedData seedData = new SeedData();

        // Users
        modelBuilder.Entity<User>().HasData(seedData.SeedUsersData());

        // Courses
        modelBuilder.Entity<Course>().HasData(seedData.SeedCoursesData());

        // Lessons
        modelBuilder.Entity<Lesson>().HasData(seedData.SeedLessonsData());

        // Enrollments
        modelBuilder.Entity<Enrollment>().HasData(seedData.SeedEnrollmentsData());

        // Progress
        modelBuilder.Entity<Progress>().HasData(seedData.SeedProgressesData());
    }
}
