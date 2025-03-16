using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearning.API;

public class User
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    public virtual ICollection<Progress> Progresses { get; set; } = new HashSet<Progress>();
    public virtual ICollection<Course> CreatedCourses { get; set; } = new HashSet<Course>();
}
