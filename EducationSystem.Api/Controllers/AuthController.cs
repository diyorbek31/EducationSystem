using EducationSystem.Service.DTOs.Authorization;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> PostAsync(LoginDto login)
    {
        var token = await _authService.AuthenticateAsync(login);
        return Ok(new
        {
            StatusCode = 200,
            Message = "Success",
            Data = token
        });
    }

}
