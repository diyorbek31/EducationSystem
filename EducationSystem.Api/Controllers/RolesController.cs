using EducationSystem.Api.Model;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.DTOs.RoleContracts;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

public class RolesController(
    IRoleService roleService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.RetrieveAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.RetrieveByIdAsync(id)
        });

    [HttpPost]
    public async Task<IActionResult> PostAsync(RoleForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.CreateAsync(dto)
        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.RemoveAsync(id)
        });
    [HttpPut]
    public async Task<IActionResult> PutAsync(RoleForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await roleService.UpdateAsync(dto)
        });
}
