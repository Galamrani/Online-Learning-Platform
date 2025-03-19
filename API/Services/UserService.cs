using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace OnlineLearning.API;

public class UserService(LearningPlatformDbContext _dbContext) : IUserService
{

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
            Password = Cyber.HashPassword(registerDto.Password)
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return JwtHelper.GetNewToken(user);
    }

    public async Task<string?> LoginAsync(CredentialsDto credentialsDto)
    {
        User? user = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == credentialsDto.Email.ToLower());

        if (user == null || user.Password != Cyber.HashPassword(credentialsDto.Password))
        {
            return null;
        }

        return JwtHelper.GetNewToken(user);
    }

    //

    private async Task<bool> IsEmailExists(string email)
    {
        return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email == email.ToLower());
    }
}
