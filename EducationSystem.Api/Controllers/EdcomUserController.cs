using EducationSystem.Service.DTOs.EdcomDto;
using EducationSystem.Service.Integration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class EdcomUserController : ControllerBase
    {
        private readonly IEdcomUserService _edcomUserService;

        public EdcomUserController(IEdcomUserService edcomUserService)
        {
            _edcomUserService = edcomUserService;
        }
        /// <summary>
        /// Get all Edcom users
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> GetAllEdcomUsersAsync([FromBody] LoginRequest request)
        {
            try
            {
                var users = await _edcomUserService.GetAllEdcomUsersAsync(request);
                return Ok(users);
            }
            catch (HttpRequestException ex)
            {
                // Network / API errors
                return StatusCode(StatusCodes.Status502BadGateway,
                    new { message = "Failed to connect to Edcom API", detail = ex.Message });
            }
            catch (Exception ex)
            {
                // Any other error
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occurred while retrieving users", detail = ex.Message });
            }
        }

        /// <summary>
        /// Retrieve an Edcom user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> GetEdcomUserByIdAsync(long id, [FromBody] LoginRequest request)
        {
            var user = await _edcomUserService.GetEdcomUserAsync(id,request);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(user);
        }
    }
}
