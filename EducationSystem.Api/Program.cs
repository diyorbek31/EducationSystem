using EducationSystem.Api.Extensions;
using EducationSystem.Api.Helpers;
using EducationSystem.Api.Middleware;
using EducationSystem.Data.DbContexts;
using EducationSystem.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Threading.Tasks;


namespace EducationSystem.Api
{
    public partial class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();

            // Register the DbContext with PostgreSQL
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            // Register custom services
            builder.Services.AddCustomService();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            // Configure JWT authentication
            builder.Services.AddJwtService(builder.Configuration);

            builder.Services.AddAuthorization(); 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger();

            // Configure Serilog
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            builder.Services.AddPermissionPolicies();

            var app = builder.Build();
            //await Dependencies.MapEnumsToEntityAsync(app);

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // Use custom middleware for global exception handling
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication(); 
            app.UseAuthorization();
            

            app.MapControllers();

            //for seed data default
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await dbContext.SeedAsync();
            }

            app.Run();
        }
    }
    public partial class Program { }
}
