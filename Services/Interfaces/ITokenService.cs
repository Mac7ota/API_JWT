namespace DefaultNamespace.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}