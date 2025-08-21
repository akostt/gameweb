using GameWeb.Persistence.Configurations;
using GameWeb.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CredentialsEntity> Credentials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CredentialsConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}