using DefaultNamespace.Interfaces;

namespace DefaultNamespace;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public void AddUser(User user)
    {
        _userRepository.Add(user);
    }
    
    public User? GetUserByUserName(string userName)
    {
        return _userRepository.GetByUserName(userName);
    }
}
