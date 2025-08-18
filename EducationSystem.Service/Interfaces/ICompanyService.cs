using EducationSystem.Service.DTOs.Companies;
using EducationSystem.Service.DTOs.EdcomDto;

namespace EducationSystem.Service.Interfaces;

public interface ICompanyService
{
    Task<CompanyResponse> GetCompanyByTinAsync(string tin, LoginRequest request);
}
