namespace OnlineLearning.API;

public interface IJwtService
{
    string GenerateToken(User user);
}