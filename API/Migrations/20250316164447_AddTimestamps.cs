using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearning.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("08e7e82f-f469-424f-8138-1a26fded532a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("033cccf9-fa5d-4655-b4d6-48c118450847"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("4094d7bc-f240-41d4-8f65-76587a649d1a"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("73c3091c-cb10-4eb3-8260-25b9759daa85"));

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: new Guid("39e7e5c2-6539-4940-a70c-010fb89aa082"));

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: new Guid("6468d7b7-1d17-4566-9db7-0676277bdc1e"));

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: new Guid("954fa1ba-f336-4464-8a2c-c9e521987fc3"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("86aedca3-dd0a-4931-806f-e7436597f162"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a8fa8e54-8ea3-4126-92db-e277c579e5e6"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ef94e3e1-2fb5-45d3-a996-961a15c44571"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("370eee4e-0dbd-420a-a715-b0e142eb237e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ccccac04-f9f3-48c3-96b8-9646ade4e303"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastWatchedAt",
                table: "Progresses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrolledAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("50d0cecc-a63a-48a9-9b0c-8a281550cce7"), "john@example.com", "John", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" },
                    { new Guid("6a9dba6c-8c4e-428b-90ce-36e713db12d6"), "bart@example.com", "Bart", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" },
                    { new Guid("c5669be5-af83-416c-be8b-f15cb6da4909"), "sarah@example.com", "Sarah", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("45f9a3ac-00d7-47c4-a36b-83dcc2a06dfd"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("50d0cecc-a63a-48a9-9b0c-8a281550cce7"), "Deep dive into EF Core with practical examples and best practices.", "Advanced Entity Framework Core" },
                    { new Guid("f52dc15e-90a2-41e7-b51b-baafffeccdd5"), new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("50d0cecc-a63a-48a9-9b0c-8a281550cce7"), "A comprehensive course covering the basics of C# programming language.", "Introduction to C# Programming" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "UserId" },
                values: new object[] { new Guid("9103d6cc-15af-4f26-89bb-412f34e5e9c8"), new Guid("f52dc15e-90a2-41e7-b51b-baafffeccdd5"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5669be5-af83-416c-be8b-f15cb6da4909") });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "Description", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { new Guid("8269ed3a-9a4a-4ae8-aa44-008eb11e66c9"), new Guid("45f9a3ac-00d7-47c4-a36b-83dcc2a06dfd"), "If statements, loops, and switch cases.", "Control Structures", "https://www.youtube.com/watch?v=IzzNzSXkCMM" },
                    { new Guid("8797cc75-801c-4335-bbaa-ff7696ccf819"), new Guid("f52dc15e-90a2-41e7-b51b-baafffeccdd5"), "Installation and setup of development environment.", "Getting Started with C#", "https://www.youtube.com/watch?v=ravLFzIguCM" },
                    { new Guid("acfebc13-6f6a-4262-aa9e-e50931dd5b96"), new Guid("45f9a3ac-00d7-47c4-a36b-83dcc2a06dfd"), "If statements, loops, and switch cases.", "Control Structures", "https://www.youtube.com/watch?v=IzzNzSXkCMM" },
                    { new Guid("f4b23748-2c47-4ae9-a3e4-a50c6a0d1090"), new Guid("45f9a3ac-00d7-47c4-a36b-83dcc2a06dfd"), "If statements, loops, and switch cases.", "Control Structures", "https://www.youtube.com/watch?v=IzzNzSXkCMM" },
                    { new Guid("fcbaad04-41e2-4d13-b9c2-a04f4011d8f8"), new Guid("f52dc15e-90a2-41e7-b51b-baafffeccdd5"), "Understanding variables and different data types in C#.", "Variables and Data Types", "https://www.youtube.com/watch?v=_D-HCF3jZKk" }
                });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "Id", "LastWatchedAt", "LessonId", "UserId" },
                values: new object[,]
                {
                    { new Guid("417d071e-a727-4571-a71d-e2b69ae23865"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fcbaad04-41e2-4d13-b9c2-a04f4011d8f8"), new Guid("c5669be5-af83-416c-be8b-f15cb6da4909") },
                    { new Guid("7ae63ef6-6fea-4a98-9dcf-5624a0c57cb6"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8797cc75-801c-4335-bbaa-ff7696ccf819"), new Guid("6a9dba6c-8c4e-428b-90ce-36e713db12d6") },
                    { new Guid("9d36a1a0-c4b7-4431-85be-5046c7d1abc7"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8797cc75-801c-4335-bbaa-ff7696ccf819"), new Guid("c5669be5-af83-416c-be8b-f15cb6da4909") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("9103d6cc-15af-4f26-89bb-412f34e5e9c8"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("8269ed3a-9a4a-4ae8-aa44-008eb11e66c9"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("acfebc13-6f6a-4262-aa9e-e50931dd5b96"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("f4b23748-2c47-4ae9-a3e4-a50c6a0d1090"));

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: new Guid("417d071e-a727-4571-a71d-e2b69ae23865"));

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: new Guid("7ae63ef6-6fea-4a98-9dcf-5624a0c57cb6"));

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: new Guid("9d36a1a0-c4b7-4431-85be-5046c7d1abc7"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("45f9a3ac-00d7-47c4-a36b-83dcc2a06dfd"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("8797cc75-801c-4335-bbaa-ff7696ccf819"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("fcbaad04-41e2-4d13-b9c2-a04f4011d8f8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6a9dba6c-8c4e-428b-90ce-36e713db12d6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5669be5-af83-416c-be8b-f15cb6da4909"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f52dc15e-90a2-41e7-b51b-baafffeccdd5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50d0cecc-a63a-48a9-9b0c-8a281550cce7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastWatchedAt",
                table: "Progresses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrolledAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("370eee4e-0dbd-420a-a715-b0e142eb237e"), "bart@example.com", "Bart", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" },
                    { new Guid("ccccac04-f9f3-48c3-96b8-9646ade4e303"), "john@example.com", "John", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" },
                    { new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497"), "sarah@example.com", "Sarah", "ol7P+JWmNfXtag31+7OW58hUXbIXMvJm4eFqmepOqbesGfnKytuRXpMeGXyZnPIZDYLSBnrjfzWlkPu4MVPtrw==" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("86aedca3-dd0a-4931-806f-e7436597f162"), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ccccac04-f9f3-48c3-96b8-9646ade4e303"), "Deep dive into EF Core with practical examples and best practices.", "Advanced Entity Framework Core" },
                    { new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"), new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ccccac04-f9f3-48c3-96b8-9646ade4e303"), "A comprehensive course covering the basics of C# programming language.", "Introduction to C# Programming" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "UserId" },
                values: new object[] { new Guid("08e7e82f-f469-424f-8138-1a26fded532a"), new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497") });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CourseId", "Description", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { new Guid("033cccf9-fa5d-4655-b4d6-48c118450847"), new Guid("86aedca3-dd0a-4931-806f-e7436597f162"), "If statements, loops, and switch cases.", "Control Structures", "https://www.youtube.com/watch?v=IzzNzSXkCMM" },
                    { new Guid("4094d7bc-f240-41d4-8f65-76587a649d1a"), new Guid("86aedca3-dd0a-4931-806f-e7436597f162"), "If statements, loops, and switch cases.", "Control Structures", "https://www.youtube.com/watch?v=IzzNzSXkCMM" },
                    { new Guid("73c3091c-cb10-4eb3-8260-25b9759daa85"), new Guid("86aedca3-dd0a-4931-806f-e7436597f162"), "If statements, loops, and switch cases.", "Control Structures", "https://www.youtube.com/watch?v=IzzNzSXkCMM" },
                    { new Guid("a8fa8e54-8ea3-4126-92db-e277c579e5e6"), new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"), "Understanding variables and different data types in C#.", "Variables and Data Types", "https://www.youtube.com/watch?v=_D-HCF3jZKk" },
                    { new Guid("ef94e3e1-2fb5-45d3-a996-961a15c44571"), new Guid("8b2d3a87-375d-42b0-8f8d-10604f1cf5f7"), "Installation and setup of development environment.", "Getting Started with C#", "https://www.youtube.com/watch?v=ravLFzIguCM" }
                });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "Id", "LastWatchedAt", "LessonId", "UserId" },
                values: new object[,]
                {
                    { new Guid("39e7e5c2-6539-4940-a70c-010fb89aa082"), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a8fa8e54-8ea3-4126-92db-e277c579e5e6"), new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497") },
                    { new Guid("6468d7b7-1d17-4566-9db7-0676277bdc1e"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef94e3e1-2fb5-45d3-a996-961a15c44571"), new Guid("ddac6fe5-55a7-4755-a8de-414d6f1c4497") },
                    { new Guid("954fa1ba-f336-4464-8a2c-c9e521987fc3"), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef94e3e1-2fb5-45d3-a996-961a15c44571"), new Guid("370eee4e-0dbd-420a-a715-b0e142eb237e") }
                });
        }
    }
}
