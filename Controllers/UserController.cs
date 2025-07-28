using Microsoft.AspNetCore.Mvc;
using SkillHub.Data;
using SkillHub.Models;

namespace SkillHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email);
        if (user == null) return NotFound("User not found");
        if (user.Password != loginDto.Password) return Unauthorized("Incorrect password");
        return Ok("Login successful");
    }
}
