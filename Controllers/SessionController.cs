using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillHub.Data;
using SkillHub.Models;
using SkillHub.Models.DTOs;
using System.Security.Claims;

namespace SkillHub.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    private readonly AppDbContext _db;

    public SessionController(AppDbContext db) => _db = db;

    [HttpGet]
    public IActionResult GetAll() => Ok(_db.Sessions.ToList());

    [Authorize(Roles = "Mentor")]
    [HttpPost]
    public IActionResult Create(SessionDto dto)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var mentorId))
            return BadRequest("Invalid user ID");
        
        var session = new Session
        {
            Title = dto.Title,
            Description = dto.Description,
            MentorId = mentorId
        };
        
        _db.Sessions.Add(session);
        _db.SaveChanges();
        
        return Ok(session);
    }
}