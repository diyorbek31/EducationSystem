using EducationSystem.Service.DTOs.Companies;
using EducationSystem.Service.DTOs.EdcomDto;
using EducationSystem.Service.Integration;
using EducationSystem.Service.Interfaces;
using Newtonsoft.Json;

namespace EducationSystem.Service.Services;

public class CompanyService : BaseEdcomService, ICompanyService
{
    public CompanyService(IHttpClientFactory factory) : base(factory) { }
    public async Task<CompanyResponse> GetCompanyByTinAsync(string tin, LoginRequest request)
    {
        await InitializeAsync(request);

        var response = await _client.GetAsync($"/gateway/api-scoring/api/soliq/companytin/{tin}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<CompanyResponse>(json)!;
        return result;
    }
}
