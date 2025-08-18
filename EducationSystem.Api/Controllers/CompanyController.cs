using EducationSystem.Service.DTOs.Companies;
using EducationSystem.Service.DTOs.EdcomDto;
using EducationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Api.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]
public class CompanyController
{
    private readonly ICompanyService _service;

    public CompanyController(ICompanyService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<CompanyResponse> GetCompanyDataFromSoliqAsync(string tin, [FromBody] LoginRequest request)
    {
        var companies = await _service.GetCompanyByTinAsync(tin,request);
        return companies;
    }
}
