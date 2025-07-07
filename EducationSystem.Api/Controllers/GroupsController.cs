using EducationSystem.Api.Model;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly IGroupService groupService;
    public GroupsController(IGroupService groupService)
    {
        this.groupService = groupService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.groupService.RetrieveAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.groupService.RetrieveByIdAsync(id)
        });

    [HttpPost]
    public async Task<IActionResult> PostAsync(GroupForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.groupService.CreateAsync(dto)
        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.groupService.RemoveAsync(id)
        });
    [HttpPut]
    public async Task<IActionResult> PutAsync(GroupForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.groupService.UpdateAsync(dto)
        });
}
