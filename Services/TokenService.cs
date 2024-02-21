using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DefaultNamespace.Interfaces;
using System.Text;
using Microsoft.IdentityModel.Tokens;


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
        
       var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? String.Empty));
       
       var issuer = _configuration["Jwt:Issuer"] ?? String.Empty;
       var audience = _configuration["Jwt:Audience"] ?? String.Empty;
       
       var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
       
       var tokensOptions = new JwtSecurityToken(
           issuer: issuer,
           audience: audience,
           claims: new []
           {
               new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
           },
           expires: DateTime.Now.AddMinutes(60),
           signingCredentials: signingCredentials
       );
       
       var token = new JwtSecurityTokenHandler().WriteToken(tokensOptions);
       return token;
    }
}