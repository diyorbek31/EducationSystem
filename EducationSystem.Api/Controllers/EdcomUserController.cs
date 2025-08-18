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

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var users = await _edcomUserService.GetEdcomUserAsync();
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
    }
}
