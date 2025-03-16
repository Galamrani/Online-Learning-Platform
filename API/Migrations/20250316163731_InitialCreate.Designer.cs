﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineLearning.API;

#nullable disable

namespace OnlineLearning.API.Migrations
{
    [DbContext(typeof(LearningPlatformDbContext))]
    [Migration("20250316163731_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineLearning.API.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"),
                            CreatedAt = new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = new Guid("ccccac04-f9f3-48c3-96b8-9646ade4e303"),
                            Description = "A comprehensive course covering the basics of C# programming language.",
                            Title = "Introduction to C# Programming"
                        },
                        new
                        {
                            Id = new Guid("86aedca3-dd0a-4931-806f-e7436597f162"),
                            CreatedAt = new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = new Guid("ccccac04-f9f3-48c3-96b8-9646ade4e303"),
                            Description = "Deep dive into EF Core with practical examples and best practices.",
                            Title = "Advanced Entity Framework Core"
                        });
                });

            modelBuilder.Entity("OnlineLearning.API.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnrolledAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("08e7e82f-f469-424f-8138-1a26fded532a"),
                            CourseId = new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"),
                            EnrolledAt = new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497")
                        });
                });

            modelBuilder.Entity("OnlineLearning.API.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef94e3e1-2fb5-45d3-a996-961a15c44571"),
                            CourseId = new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"),
                            Description = "Installation and setup of development environment.",
                            Title = "Getting Started with C#",
                            VideoUrl = "https://www.youtube.com/watch?v=ravLFzIguCM"
                        },
                        new
                        {
                            Id = new Guid("a8fa8e54-8ea3-4126-92db-e277c579e5e6"),
                            CourseId = new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"),
                            Description = "Understanding variables and different data types in C#.",
                            Title = "Variables and Data Types",
                            VideoUrl = "https://www.youtube.com/watch?v=_D-HCF3jZKk"
                        },
                        new
                        {
                            Id = new Guid("73c3091c-cb10-4eb3-8260-25b9759daa85"),
                            CourseId = new Guid("86aedca3-dd0a-4931-806f-e7436597f162"),
                            Description = "If statements, loops, and switch cases.",
                            Title = "Control Structures",
                            VideoUrl = "https://www.youtube.com/watch?v=IzzNzSXkCMM"
                        },
                        new
                        {
                            Id = new Guid("4094d7bc-f240-41d4-8f65-76587a649d1a"),
                            CourseId = new Guid("86aedca3-dd0a-4931-806f-e7436597f162"),
                            Description = "If statements, loops, and switch cases.",
                            Title = "Control Structures",
                            VideoUrl = "https://www.youtube.com/watch?v=IzzNzSXkCMM"
                        },
                        new
                        {
                            Id = new Guid("033cccf9-fa5d-4655-b4d6-48c118450847"),
                            CourseId = new Guid("86aedca3-dd0a-4931-806f-e7436597f162"),
                            Description = "If statements, loops, and switch cases.",
                            Title = "Control Structures",
                            VideoUrl = "https://www.youtube.com/watch?v=IzzNzSXkCMM"
                        });
                });

            modelBuilder.Entity("OnlineLearning.API.Progress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastWatchedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("Progresses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6468d7b7-1d17-4566-9db7-0676277bdc1e"),
                            LastWatchedAt = new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = new Guid("ef94e3e1-2fb5-45d3-a996-961a15c44571"),
                            UserId = new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497")
                        },
                        new
                        {
                            Id = new Guid("39e7e5c2-6539-4940-a70c-010fb89aa082"),
                            LastWatchedAt = new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = new Guid("a8fa8e54-8ea3-4126-92db-e277c579e5e6"),
                            UserId = new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497")
                        },
                        new
                        {
                            Id = new Guid("954fa1ba-f336-4464-8a2c-c9e521987fc3"),
                            LastWatchedAt = new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LessonId = new Guid("ef94e3e1-2fb5-45d3-a996-961a15c44571"),
                            UserId = new Guid("370eee4e-0dbd-420a-a715-b0e142eb237e")
                        });
                });

            modelBuilder.Entity("OnlineLearning.API.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ccccac04-f9f3-48c3-96b8-9646ade4e303"),
                            Email = "john@example.com",
                            Name = "John",
                            Password = "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw=="
                        },
                        new
                        {
                            Id = new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497"),
                            Email = "sarah@example.com",
                            Name = "Sarah",
                            Password = "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw=="
                        },
                        new
                        {
                            Id = new Guid("370eee4e-0dbd-420a-a715-b0e142eb237e"),
                            Email = "bart@example.com",
                            Name = "Bart",
                            Password = "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw=="
                        });
                });

            modelBuilder.Entity("OnlineLearning.API.Course", b =>
                {
                    b.HasOne("OnlineLearning.API.User", "Creator")
                        .WithMany("CreatedCourses")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("OnlineLearning.API.Enrollment", b =>
                {
                    b.HasOne("OnlineLearning.API.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineLearning.API.User", "User")
                        .WithMany("Enrollments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineLearning.API.Lesson", b =>
                {
                    b.HasOne("OnlineLearning.API.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("OnlineLearning.API.Progress", b =>
                {
                    b.HasOne("OnlineLearning.API.Lesson", "Lesson")
                        .WithMany("Progresses")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineLearning.API.User", "User")
                        .WithMany("Progresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineLearning.API.Course", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("OnlineLearning.API.Lesson", b =>
                {
                    b.Navigation("Progresses");
                });

            modelBuilder.Entity("OnlineLearning.API.User", b =>
                {
                    b.Navigation("CreatedCourses");

                    b.Navigation("Enrollments");

                    b.Navigation("Progresses");
                });
#pragma warning restore 612, 618
        }
    }
}
