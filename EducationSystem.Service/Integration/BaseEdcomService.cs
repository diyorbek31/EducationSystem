using EducationSystem.Service.DTOs.EdcomDto;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EducationSystem.Service.Integration;

public class BaseEdcomService : IBaseEdcomService
{
    protected readonly HttpClient _client;
    private readonly IHttpClientFactory _factory;

    public BaseEdcomService(IHttpClientFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
        _client.BaseAddress = new Uri("https://stage.api.edcom.uz");
    }

    public async Task InitializeAsync()
    {
        var token = await GetAuthTokenAsync();
        _client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", token);
    }

    private async Task<string> GetAuthTokenAsync()
    {
        var loginRequest = new LoginRequest
        {
            Username = "admin",
            Password = "password123"
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
