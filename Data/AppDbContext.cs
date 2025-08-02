using Microsoft.EntityFrameworkCore;
using SkillHub.Models;

namespace SkillHub.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().Property(u => u.Role).HasDefaultValue("Learner");
    }
}