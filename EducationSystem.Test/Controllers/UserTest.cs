using EducationSystem.Api;
using EducationSystem.Data.DbContexts;
using EducationSystem.Domain.Enities;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http.Json;

namespace EducationSystem.Test.Controllers;

public class UserTest
{
    private readonly WebApplicationFactory<Program> _factory;

    public UserTest()
    {
        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Testing");

                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll(typeof(DbContextOptions<AppDbContext>));
                    services.RemoveAll(typeof(AppDbContext));

                    var provider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDb")
                               .UseInternalServiceProvider(provider);
                    });
                });
            });

    }
    [Fact]
    public async Task OnGetUsers_WhenExecuteApi_ShouldReturnExpectedUsers()
    {
        // Arrange
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedService = scope.ServiceProvider;
            var dbContext = scopedService.GetRequiredService<AppDbContext>();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.Users.Add(new User()
            {
                Id = 2,
                FirstName = "Diyorbek",
                LastName = "Juraev",
                Email = "31diyor",
                Password = "3105",
                UserName = "juraev",
                GroupId = 1,
                RoleId = 1
            });

            dbContext.SaveChanges();
        }

        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("api/users");
        var result = await response.Content.ReadFromJsonAsync<Response<List<User>>>();

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(200);
        result.Data.Should().NotBeNull();
        result.Data.Count.Should().Be(1);

        var user = result.Data[0];
        user.FirstName.Should().Be("Diyorbek");
        user.LastName.Should().Be("Juraev");
        user.Email.Should().Be("31diyor");
    }
}
