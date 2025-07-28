using SkillHub.Services.Interfaces;

namespace SkillHub.Services;

public class AuthService : IAuthService
{
    public string Login(string email, string password)
    {
        return "fake-jwt-token";  
    }
}
