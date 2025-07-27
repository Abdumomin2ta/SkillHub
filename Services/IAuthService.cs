namespace SkillHub.Services.Interfaces;

public interface IAuthService
{
    string Login(string email, string password);
}
