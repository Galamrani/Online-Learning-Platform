using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class UserService : IUserService
{
    private readonly LearningPlatformDbContext _dbContext;
    private readonly IJwtService _jwtService;

    public UserService(LearningPlatformDbContext dbContext, IJwtService jwtService)
    {
        _dbContext = dbContext;
        _jwtService = jwtService;
    }

    public async Task<string?> RegisterAsync(RegisterDto registerDto)
    {
        if (await IsEmailExists(registerDto.Email))
        {
            return null;
        }

        User user = new User()
        {
            Name = registerDto.Name,
            Email = registerDto.Email.ToLower(),
            Password = PasswordHasher.HashPassword(registerDto.Password)
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return _jwtService.GenerateToken(user);
        // return JwtHelper.GetNewToken(user);
    }

    public async Task<string?> LoginAsync(CredentialsDto credentialsDto)
    {
        User? user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == credentialsDto.Email.ToLower());

        if (user == null || user.Password != PasswordHasher.HashPassword(credentialsDto.Password))
        {
            return null;
        }

        return _jwtService.GenerateToken(user);
        // return JwtHelper.GetNewToken(user);
    }

    //

    private async Task<bool> IsEmailExists(string email)
    {
        return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email == email.ToLower());
    }
}
