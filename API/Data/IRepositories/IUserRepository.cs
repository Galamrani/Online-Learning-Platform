namespace OnlineLearning.API;

public interface IUserRepository
{
    public Task<bool> IsEmailExists(string email);
    public Task<User> AddUserAsync(User user);
    public Task<User?> GetUserByEmailAsync(string email);
}
