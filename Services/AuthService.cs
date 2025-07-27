using Microsoft.Extensions.Configuration;
using SkillHub.Services.Interfaces;

namespace SkillHub.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;

    public AuthService(IConfiguration config)
    {
        _config = config;
    }

    public string Login(string email, string password)
    {
        return "fake-jwt-token";
    }
}
