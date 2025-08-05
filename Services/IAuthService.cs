using SkillHub.DTOs;
using SkillHub.Models;

namespace SkillHub.Services.Interfaces;

public interface IAuthService
{
    Task<User> Register(RegisterRequest request);
    Task<string> Login(LoginRequest request);
}