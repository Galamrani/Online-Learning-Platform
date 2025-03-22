using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearning.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrolledAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastWatchedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progresses_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Progresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("1afa0c56-8a71-4b23-8dfd-34cbe9d5bd6d"), "john@example.com", "John", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" },
                    { new Guid("3a3c377a-873c-4953-9ca2-c422b4ae40da"), "sarah@example.com", "Sarah", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" },
                    { new Guid("b0ea7082-1893-4a8d-8793-2c97d1b1f26c"), "bart@example.com", "Bart", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("4aea7849-3c0e-4a5d-ba7d-59292ffa171d"), new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1afa0c56-8a71-4b23-8dfd-34cbe9d5bd6d"), "A comprehensive course covering the basics of C# programming language, including syntax, data types, and object-oriented concepts.", "Introduction to C# Programming" },
                    { new Guid("bd6a270f-001e-48bc-8f01-33370452f475"), new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1afa0c56-8a71-4b23-8dfd-34cbe9d5bd6d"), "A hands-on course focused on writing effective unit tests in .NET using xUnit, Moq, and Test-Driven Development (TDD) principles.", "Unit Testing in .NET" },
                    { new Guid("feab60e5-5d25-4df2-ae56-4723bb423d79"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1afa0c56-8a71-4b23-8dfd-34cbe9d5bd6d"), "An in-depth guide to working with Entity Framework Core, covering migrations, relationships, and performance optimization.", "Mastering Entity Framework Core" },
                    { new Guid("fefbefdf-c3bf-4c81-87b9-96abf64d11f3"), new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1afa0c56-8a71-4b23-8dfd-34cbe9d5bd6d"), "Learn how to design and develop robust REST APIs using ASP.NET Core, covering controllers, authentication, and best practices.", "Building RESTful APIs with ASP.NET Core" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "UserId" },
                values: new object[] { new Guid("1f0fe16a-21b7-4977-9193-4e8a701656fb"), new Guid("4aea7849-3c0e-4a5d-ba7d-59292ffa171d"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a3c377a-873c-4953-9ca2-c422b4ae40da") });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "Description", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { new Guid("06af739c-4ee4-4eaa-b7cc-49fab8816994"), new Guid("feab60e5-5d25-4df2-ae56-4723bb423d79"), "Learn how to use LINQ queries in EF Core to fetch data.", "Querying Data with LINQ", "https://www.youtube.com/watch?v=DuozyaJQQ1U" },
                    { new Guid("0e853ab8-9209-4809-8d76-3fd105905bb8"), new Guid("4aea7849-3c0e-4a5d-ba7d-59292ffa171d"), "Installation and setup of development environment.", "Getting Started with C#", "https://www.youtube.com/watch?v=ravLFzIguCM" },
                    { new Guid("77bdb0e2-4a6a-43f6-b17c-816a24153f06"), new Guid("4aea7849-3c0e-4a5d-ba7d-59292ffa171d"), "Understanding variables and different data types in C#.", "Variables and Data Types", "https://www.youtube.com/watch?v=_D-HCF3jZKk" },
                    { new Guid("9d11901e-05cf-4239-8b07-0ef92e561e23"), new Guid("fefbefdf-c3bf-4c81-87b9-96abf64d11f3"), "Implementing authentication and role-based authorization in ASP.NET Core.", "Authentication and Authorization", "https://www.youtube.com/watch?v=eUW2CYAT1Nk" },
                    { new Guid("a1a79889-2379-457d-a812-b3c54ae1b02c"), new Guid("feab60e5-5d25-4df2-ae56-4723bb423d79"), "How to create and apply migrations in EF Core.", "Working with Migrations", "https://www.youtube.com/watch?v=ZoKRFVBsm7E" },
                    { new Guid("a6a82716-b6fb-419d-b922-48c5518ccda4"), new Guid("4aea7849-3c0e-4a5d-ba7d-59292ffa171d"), "Learn about arithmetic, logical, and comparison operators in C#.", "Operators and Expressions", "https://www.youtube.com/watch?v=WL7QEhdqh00" },
                    { new Guid("e0db9630-1a6d-4775-baf7-9f8dcd9be612"), new Guid("fefbefdf-c3bf-4c81-87b9-96abf64d11f3"), "Understanding controllers, routing, and API responses.", "Building RESTful APIs with ASP.NET Core", "https://www.youtube.com/watch?v=JiJeZOHx0ow" },
                    { new Guid("f69240ae-e76c-4f7d-9e62-c9b953082e57"), new Guid("feab60e5-5d25-4df2-ae56-4723bb423d79"), "Overview of EF Core and setting up the DbContext.", "Introduction to Entity Framework Core", "https://www.youtube.com/watch?v=KcFWOMbGJ4M" }
                });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "Id", "LastWatchedAt", "LessonId", "UserId" },
                values: new object[,]
                {
                    { new Guid("787c70a9-9cef-49b4-8067-1731ed414a1e"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0e853ab8-9209-4809-8d76-3fd105905bb8"), new Guid("3a3c377a-873c-4953-9ca2-c422b4ae40da") },
                    { new Guid("85c9f78f-3e74-46eb-a53f-9ad304f45627"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("77bdb0e2-4a6a-43f6-b17c-816a24153f06"), new Guid("3a3c377a-873c-4953-9ca2-c422b4ae40da") },
                    { new Guid("bfd220df-c171-414f-9a07-908f2e94da74"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0e853ab8-9209-4809-8d76-3fd105905bb8"), new Guid("b0ea7082-1893-4a8d-8793-2c97d1b1f26c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_LessonId",
                table: "Progresses",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_UserId",
                table: "Progresses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
