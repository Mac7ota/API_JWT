namespace DefaultNamespace.Interfaces;

public interface IUserRepository
{
    void Add(User user);
    User? GetByUserName(string userName);
}