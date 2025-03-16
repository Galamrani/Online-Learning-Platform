
using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class UserRepository : IUserRepository
{
    private readonly LearningPlatformDbContext _dbContext;

    public UserRepository(LearningPlatformDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> AddUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return user;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email);
    }

    public Task<bool> IsEmailExists(string email)
    {
        return _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email == email);
    }
}
