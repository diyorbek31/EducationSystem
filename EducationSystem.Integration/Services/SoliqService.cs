using EducationSystem.Integration.BaseIntegration;
using EducationSystem.Integration.CompanyResponses;
using EducationSystem.Integration.Interfaces;
using EducationSystem.Integration.Requests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EducationSystem.Integration.Services;

public class SoliqService : BaseIntegrationService,ISoliqService
{
    public SoliqService(IHttpClientFactory factory) : base(factory) {}
    public async Task<CompanyResponse> GetSoliqDataByTinAsync(string tin, [FromBody] LoginRequest request)
    {
        await InitiliazeAsync(request);

        var response = await _client.GetAsync($"/gateway/api-scoring/api/soliq/companytin/{tin}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<CompanyResponse>(json)!;
        return result;
    }
}
