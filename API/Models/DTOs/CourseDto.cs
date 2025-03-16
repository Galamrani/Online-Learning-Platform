namespace OnlineLearning.API;

public class CourseDto
{
    public Guid Id { get; set; }

    public Guid CreatorId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<LessonDto>? Lessons { get; set; }
}
