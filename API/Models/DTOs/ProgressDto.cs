namespace OnlineLearning.API;

public class ProgressDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid LessonId { get; set; }

    public DateTime LastWatchedAt { get; set; }
}
