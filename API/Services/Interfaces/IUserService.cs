namespace OnlineLearning.API;

public interface IUserService
{
    Task<string?> RegisterAsync(RegisterDto registerDto);
    Task<string?> LoginAsync(CredentialsDto credentialsDto);
}