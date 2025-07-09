using EducationSystem.Domain.Enities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EducationSystem.Service.Integration;

public class EdcomUserService : IEdcomUserService
{
    public async Task<List<EdcomUser>> GetEdcomUserAsync(string token)
    {
        using var client = new HttpClient();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.GetAsync("https://stage.api.edcom.uz/gateway/api-auth/users");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Failed to retrieve users from Edcom API.");
        }

        var content = await response.Content.ReadAsStringAsync();

        var users = JsonSerializer.Deserialize<List<EdcomUser>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return users ?? new List<EdcomUser>();
    }
}
