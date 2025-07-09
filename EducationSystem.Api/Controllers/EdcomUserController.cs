using EducationSystem.Service.Integration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;
[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]
public class EdcomUserController : ControllerBase
{
    private readonly IEdcomUserService edcomUserService;

    public EdcomUserController(IEdcomUserService edcomUserService)
    {
        this.edcomUserService = edcomUserService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9." +
            "eyJpZCI6IjEiLCJpbm4tb3ItcGluZmwiOiIxMjM0NTY3ODkxMDExMSIsImxhbmciOiJ1eiIsImV4cCI6ODk1MjAzNDUwOSwiaXNzIjoiZGV2LmVkY29tLnV6IiwiYXVkIjoiZGV2LmVkY29tLnV6In0." +
            "iBAS5O7evnSX7U5rFvwtzuqscmu0c42g9kzRQX4GTPQ";
        try
        {
            var users = await edcomUserService.GetEdcomUserAsync(token);

            return Ok(new
            {
                StatusCode = 200,
                Message = "Success",
                Data = users
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                StatusCode = 400,
                Message = "Error retrieving users from Edcom API.",
                Error = ex.Message
            });

        }
    }
}
