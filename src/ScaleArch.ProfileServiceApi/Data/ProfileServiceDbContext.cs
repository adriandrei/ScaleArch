using Microsoft.EntityFrameworkCore;
using ScaleArch.ProfileServiceApi.Models;
using System.Reflection;

namespace ScaleArch.ProfileServiceApi.Data;

public class ProfileServiceDbContext : DbContext
{
    public ProfileServiceDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
