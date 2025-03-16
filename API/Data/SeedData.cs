using OnlineLearning.API;
using System;
using System.Collections.Generic;
using System.Linq;

public class SeedData
{
    private readonly Dictionary<string, Guid> _guids;

    public SeedData()
    {
        _guids = new Dictionary<string, Guid>
        {
            // Users
            ["user1"] = Guid.NewGuid(),
            ["user2"] = Guid.NewGuid(),
            ["user3"] = Guid.NewGuid(),

            // Courses
            ["course1"] = Guid.NewGuid(),
            ["course2"] = Guid.NewGuid(),

            // Lessons
            ["lesson1"] = Guid.NewGuid(),
            ["lesson2"] = Guid.NewGuid(),
            ["lesson3"] = Guid.NewGuid(),
            ["lesson4"] = Guid.NewGuid(),
            ["lesson5"] = Guid.NewGuid()
        };
    }

    public User[] SeedUsersData()
    {
        const string defaultPassword = "Pa$$w0rd";

        return new[]
        {
            CreateUser("user1", "John", "john@example.com", defaultPassword),
            CreateUser("user2", "Sarah", "sarah@example.com", defaultPassword),
            CreateUser("user3", "Bart", "bart@example.com", defaultPassword)
        };
    }

    public Course[] SeedCoursesData()
    {
        return new[]
        {
            CreateCourse(
                "course1",
                "Introduction to C# Programming",
                "A comprehensive course covering the basics of C# programming language.",
                "user1",
                DateTime.Parse("2025-01-28")
            ),
            CreateCourse(
                "course2",
                "Advanced Entity Framework Core",
                "Deep dive into EF Core with practical examples and best practices.",
                "user1",
                DateTime.Parse("2025-02-07")
            )
        };
    }

    public Lesson[] SeedLessonsData()
    {
        return new[]
        {
            CreateLesson(
                "lesson1",
                "course1",
                "Getting Started with C#",
                "Installation and setup of development environment.",
                "https://www.youtube.com/watch?v=ravLFzIguCM"
            ),
            CreateLesson(
                "lesson2",
                "course1",
                "Variables and Data Types",
                "Understanding variables and different data types in C#.",
                "https://www.youtube.com/watch?v=_D-HCF3jZKk"
            ),
            CreateLesson(
                "lesson3",
                "course2",
                "Control Structures",
                "If statements, loops, and switch cases.",
                "https://www.youtube.com/watch?v=IzzNzSXkCMM"
            ),
            CreateLesson(
                "lesson4",
                "course2",
                "Control Structures",
                "If statements, loops, and switch cases.",
                "https://www.youtube.com/watch?v=IzzNzSXkCMM"
            ),
            CreateLesson(
                "lesson5",
                "course2",
                "Control Structures",
                "If statements, loops, and switch cases.",
                "https://www.youtube.com/watch?v=IzzNzSXkCMM"
            )
        };
    }

    public Enrollment[] SeedEnrollmentsData()
    {
        return new[]
        {
            new Enrollment
            {
                Id = Guid.NewGuid(),
                UserId = _guids["user2"],
                CourseId = _guids["course1"],
                EnrolledAt = DateTime.Parse("2025-02-02"),
            }
        };
    }

    public Progress[] SeedProgressesData()
    {
        // Fixed the duplicate progress records issue
        return new[]
        {
            CreateProgress("user2", "lesson1", DateTime.Parse("2025-02-03")),
            CreateProgress("user2", "lesson2", DateTime.Parse("2025-02-05")),
            CreateProgress("user3", "lesson1", DateTime.Parse("2025-02-03"))
        };
    }

    // Helper methods to create entities with consistent data
    private User CreateUser(string userKey, string name, string email, string password)
    {
        return new User
        {
            Id = _guids[userKey],
            Name = name,
            Email = email,
            Password = Cyber.HashPassword(password)
        };
    }

    private Course CreateCourse(string courseKey, string title, string description, string creatorKey, DateTime createdAt)
    {
        return new Course
        {
            Id = _guids[courseKey],
            Title = title,
            Description = description,
            CreatorId = _guids[creatorKey],
            CreatedAt = createdAt
        };
    }

    private Lesson CreateLesson(string lessonKey, string courseKey, string title, string description, string videoUrl)
    {
        return new Lesson
        {
            Id = _guids[lessonKey],
            CourseId = _guids[courseKey],
            Title = title,
            Description = description,
            VideoUrl = videoUrl
        };
    }

    private Progress CreateProgress(string userKey, string lessonKey, DateTime lastWatchedAt)
    {
        return new Progress
        {
            Id = Guid.NewGuid(),
            UserId = _guids[userKey],
            LessonId = _guids[lessonKey],
            LastWatchedAt = lastWatchedAt
        };
    }
}