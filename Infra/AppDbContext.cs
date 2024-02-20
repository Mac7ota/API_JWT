using DefaultNamespace;
using Microsoft.EntityFrameworkCore;

namespace admin.Infra;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("");
}