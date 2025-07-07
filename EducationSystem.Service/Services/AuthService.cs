using EducationSystem.Domain.Enities;
using EducationSystem.Service.DTOs.Authorization;
using EducationSystem.Service.DTOs.AuthorizationContracts;
using EducationSystem.Service.Exceptions;
using EducationSystem.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql.Replication.PgOutput.Messages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EducationSystem.Service.Services;

public class AuthService(
    IUserService userService,
    IConfiguration configuration,
    IRoleService roleService) : IAuthService
{
    public async Task<LoginForResultDto> AuthenticateAsync(LoginDto login)
    {
        var user = await userService.RetrieveByEmailAsync(login.Email);
        if (user is null || login.Password is null)
            throw new CustomException(404, "User not found");

        var role = await roleService.RetrieveByIdForAuthAsync(user.RoleId);
        user.Role = role;

        return new LoginForResultDto
        {
            Token = GenerateToken(user)
        };
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim(ClaimTypes.Role, user.Role.Name.ToString()),
                 new Claim(ClaimTypes.Name, user.FirstName)
            }),
            Audience = configuration["JWT:Audience"],
            Issuer = configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
