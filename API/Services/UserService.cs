using AutoMapper;

namespace OnlineLearning.API;

public class UserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<string?> RegisterAsync(RegisterDto registerDto) //
    {
        if (await _unitOfWork.Users.IsEmailExists(registerDto.Email)) return null;

        User user = new User()
        {
            Name = registerDto.Name,
            Email = registerDto.Email.ToLower(),
            Password = Cyber.HashPassword(registerDto.Password)
        };

        User dbUser = await _unitOfWork.Users.AddUserAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return JwtHelper.GetNewToken(dbUser);
    }

    public async Task<string?> LoginAsync(CredentialsDto credentialsDto) //
    {
        User? user = await _unitOfWork.Users.GetUserByEmailAsync(credentialsDto.Email.ToLower());

        if (user == null || user.Password != Cyber.HashPassword(credentialsDto.Password)) return null;

        return JwtHelper.GetNewToken(user);
    }
}
