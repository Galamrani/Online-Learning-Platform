using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearning.API;

public class Course
{
    [Key]
    public Guid Id { get; set; }

    public Guid CreatorId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("CreatorId")]
    public virtual User? Creator { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    public ICollection<Lesson> Lessons { get; set; } = new HashSet<Lesson>();
}
