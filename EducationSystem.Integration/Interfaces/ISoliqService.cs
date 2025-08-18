using EducationSystem.Integration.CompanyResponses;
using EducationSystem.Integration.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EducationSystem.Integration.Interfaces;

public interface ISoliqService
{
    Task<CompanyResponse> GetSoliqDataByTinAsync(string tin, LoginRequest request);
}
