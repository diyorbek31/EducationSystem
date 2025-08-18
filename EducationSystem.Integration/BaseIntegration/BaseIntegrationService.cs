using EducationSystem.Integration.Requests;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace EducationSystem.Integration.BaseIntegration;

public class BaseIntegrationService : IBaseIntegrationService
{
    protected readonly HttpClient _client;
    private readonly IHttpClientFactory _factory;

    public BaseIntegrationService(IHttpClientFactory factory)
    {
        _factory = factory;
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://stage.api.edcom.uz");
    }

    public async Task InitiliazeAsync(LoginRequest request)
    {
        var token = await GetAuthTokenAsync(request);
    }

    private async Task<string> GetAuthTokenAsync(LoginRequest request)
    {
        var loginRequest = new LoginRequest
        {
            Username = request.Username,
            Password = request.Password,
        };

        var content = new StringContent(
            JsonConvert.SerializeObject(loginRequest),
            Encoding.UTF8,
            "application/json");

        var response = await _client.PostAsync(
            "/gateway/api-auth/auth/login-credentials", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var doc = JsonDocument.Parse(json);
        return doc.RootElement.GetProperty("accessToken").GetString()!;
    }

}
