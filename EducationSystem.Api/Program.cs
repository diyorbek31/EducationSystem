using EducationSystem.Api.Extensions;
using EducationSystem.Data.DbContexts;
using EducationSystem.Service.Mappers;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCustomService();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            builder.Services.AddJwtService(builder.Configuration);

            builder.Services.AddAuthorization(); 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
