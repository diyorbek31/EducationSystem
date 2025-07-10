using EducationSystem.Api.Model;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

public class PermissionsController(
    IPermissionService permissionService) : ControllerBase
{
    ///// <summary>
    ///// Get all permissions
    ///// </summary>
    ///// <param name="permission"></param>
    ///// <returns></returns>
    //[HttpGet]
    //public async Task<IActionResult> GetAllAsync()
    //{
    //    return Ok(new Response
    //    {
    //        StatusCode = 200,
    //        Message = "Success",
    //        Data = await permissionService.GetAllPermissionsAsync()
    //    });
    //}
}
