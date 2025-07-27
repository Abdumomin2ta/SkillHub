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

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }
}
