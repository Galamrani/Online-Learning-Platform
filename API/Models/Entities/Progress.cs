using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearning.API;

public class Progress
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid LessonId { get; set; }

    public DateTime LastWatchedAt { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    [ForeignKey("LessonId")]
    public Lesson Lesson { get; set; } = null!;
}
