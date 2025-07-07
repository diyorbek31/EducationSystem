using EducationSystem.Api.Helpers;
using EducationSystem.Api.Model;
using EducationSystem.Domain.Enums;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.DTOs.UserContracts;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]
public class UsersController(
    IUserService userService) : ControllerBase
{
    [HasPermission(EnumPermission.ViewUser)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.RetrieveAllAsync()
        });

    [HasPermission(EnumPermission.ViewUser)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.RetrieveByIdAsync(id)
        });

    [HasPermission(EnumPermission.CreateUser)]
    [HttpPost]
    public async Task<IActionResult> PostAsync(UserForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.CreateAsync(dto)
        });

    [HasPermission(EnumPermission.DeleteUser)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.RemoveAsync(id)
        });

    [HasPermission(EnumPermission.EditUser)]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, UserForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.UpdateAsync(id, dto)
        });
}
