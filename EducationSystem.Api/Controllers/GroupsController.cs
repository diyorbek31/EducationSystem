using EducationSystem.Api.Helpers;
using EducationSystem.Api.Model;
using EducationSystem.Domain.Congirations;
using EducationSystem.Domain.Enums;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GroupsController(
    IGroupService groupService) : ControllerBase
{
    [HasPermission(EnumPermission.ViewGroup)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await groupService.RetrieveAllAsync(@params)
        });

    [HasPermission(EnumPermission.ViewGroup)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await groupService.RetrieveByIdAsync(id)
        });

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostAsync(GroupForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await groupService.CreateAsync(dto)
        });
    [HasPermission(EnumPermission.DeleteGroup)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await groupService.RemoveAsync(id)
        });

    [HasPermission(EnumPermission.EditGroup)]
    [HttpPut]
    public async Task<IActionResult> PutAsync(GroupForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await groupService.UpdateAsync(dto)
        });
}
