using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearning.API;

public class Enrollment
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid CourseId { get; set; }

    public DateTime EnrolledAt { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    [ForeignKey("CourseId")]
    public Course Course { get; set; } = null!;
}
