using admin.Infra;
using DefaultNamespace.Interfaces;

namespace DefaultNamespace;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext = new AppDbContext();
    public void Add(User user)
    {
        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();
    }
    
    public User? GetByUserName(string userName)
    {
        return _appDbContext.Users.Find(userName);
    }
    
}