using EducationSystem.Api.Model;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.DTOs.UserContracts;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IGroupService userService;
    public UsersController(IGroupService userService)
    {
        this.userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RetrieveAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RetrieveByIdAsync(id)
        });

    [HttpPost]
    public async Task<IActionResult> PostAsync(GroupForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.CreateAsync(dto)
        });
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.RemoveAsync(id)
        });
    [HttpPut]
    public async Task<IActionResult> PutAsync(GroupForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.userService.UpdateAsync(dto)
        });
}
