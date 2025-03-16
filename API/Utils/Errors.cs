namespace OnlineLearning.API;


public abstract class BaseError
{
    public string Message { get; set; }

    protected BaseError(string message)
    {
        Message = message;
    }
}

public class RouteNotFoundError : BaseError // 404
{
    public RouteNotFoundError(string method, string route) :
        base($"Route '{route}' on method '{method}' not exits.")
    { }
}

public class CourseNoFoundError : BaseError // 400
{
    public CourseNoFoundError(Guid id) : base($"Course with id: {id} not found") { }
}

public class UserNoFoundError : BaseError // 400
{
    public UserNoFoundError(Guid id) : base($"User with id: {id} not found") { }
}

public class EnrollmentNoFoundError : BaseError // 400
{
    public EnrollmentNoFoundError(Guid userId, Guid courseId) : base($"Enrollment with userId: {userId}, courseId {courseId} not found") { }
}

public class LessonNoFoundError : BaseError // 400
{
    public LessonNoFoundError(Guid lessonId) : base($"Lesson with lessonId {lessonId} not found") { }
}

public class CourseExistsError : BaseError // 400
{
    public CourseExistsError(string title) : base($"Course with title: {title} already exists") { }
}

public class EmailExistsError : BaseError // 400
{
    public EmailExistsError(string email) : base($"Email: {email} already exists") { }
}

public class EnrollmentExistsError : BaseError // 400
{
    public EnrollmentExistsError(Guid userId, Guid courseId) : base($"Enrollment with userId: {userId}, courseId {courseId} already exists") { }
}

public class InvalidCredentials : BaseError // 400
{
    public InvalidCredentials() : base("Invalid credentials") { }
}

public class ValidationError : BaseError // 400
{
    public ValidationError(string message) : base(message) { }
}

public class InternalServerError : BaseError // 500
{
    public InternalServerError(string message) : base(message) { }
}

public class UnauthorizedError : BaseError // 401
{
    public UnauthorizedError(string message) : base(message) { }
}

public class ForbiddenError : BaseError
{
    public ForbiddenError(string message) : base(message) { }
}



