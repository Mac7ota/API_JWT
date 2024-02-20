using DefaultNamespace.Interfaces;

namespace DefaultNamespace;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public TokenService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public string GenerateToken(User user)
    {
        var _userDataBase = _userRepository.GetByUserName(user.UserName);
        if (user.UserName != _userDataBase.UserName && user.Password != _userDataBase.Password)
           return String.Empty;
        
       
    }
}