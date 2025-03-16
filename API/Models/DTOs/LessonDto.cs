namespace OnlineLearning.API;

public class LessonDto
{
    public Guid Id { get; set; }

    public Guid CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string VideoUrl { get; set; } = null!;

    public virtual ICollection<ProgressDto>? Progresses { get; set; }
}
