using EducationSystem.Domain.Authorization;
using EducationSystem.Domain.Enities;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    //public DbSet<Permission> Permissions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Role> Roles { get; set; }
    //public DbSet<RolePermission> RolePermissions { get; set; }


}
