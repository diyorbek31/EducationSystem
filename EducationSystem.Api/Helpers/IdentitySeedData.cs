using EducationSystem.Data.DbContexts;
using EducationSystem.Domain.Authorization;
using EducationSystem.Domain.Enities;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Api.Helpers;

public static class IdentitySeedData
{
    public static async Task SeedAsync(this AppDbContext dbContext)
    {
        await dbContext.Database.EnsureCreatedAsync();

        if (!dbContext.Groups.Any())
        {
            var mathGroup = new Group { Name = "Math" };
            await dbContext.Groups.AddAsync(mathGroup);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Roles.Any())
        {
            var adminRole = new Role { Name = "Admin" };
            await dbContext.Roles.AddAsync(adminRole);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Users.Any())
        {
            var group = await dbContext.Groups.FirstAsync(g => g.Name == "Math");
            var role = await dbContext.Roles.FirstAsync(r => r.Name == "Admin");

            var user = new User
            {
                FirstName = "Diyorbek",
                LastName = "Juraev",
                Email = "31diyor@gmail.com",
                Password = "westernguy",
                UserName = "diyorbek",
                GroupId = group.Id,
                RoleId = role.Id,
                CreatedAt = DateTime.UtcNow
            };

            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
