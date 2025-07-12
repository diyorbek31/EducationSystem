using EducationSystem.Api.Helpers;
using EducationSystem.Api.Model;
using EducationSystem.Domain.Congirations;
using EducationSystem.Domain.Enums;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.DTOs.RoleContracts;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]
public class RolesController(
    IRoleService roleService) : ControllerBase
{
    [HasPermission(EnumPermission.ViewRole)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.RetrieveAllAsync(@params)
        });

    [HasPermission(EnumPermission.ViewRole)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.RetrieveByIdAsync(id)
        });

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostAsync(RoleForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.CreateAsync(dto)
        });

    [HasPermission(EnumPermission.DeleteRole)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.RemoveAsync(id)
        });

    [HasPermission(EnumPermission.EditRole)]
    [HttpPut]
    public async Task<IActionResult> PutAsync(RoleForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.UpdateAsync(dto)
        });
}
