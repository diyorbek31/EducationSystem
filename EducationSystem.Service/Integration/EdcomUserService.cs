using EducationSystem.Domain.Enities;
using EducationSystem.Service.DTOs.EdcomDto;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EducationSystem.Service.Integration;

public class EdcomUserService : BaseEdcomService, IEdcomUserService
{
    public EdcomUserService(IHttpClientFactory factory) : base(factory) { }

    public async Task<List<EdcomUser>> GetEdcomUserAsync()
    {
        await InitializeAsync();

        var response = await _client.GetAsync("/gateway/api-auth/users");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<EdcomUserResponse>(json)!;
        return result.Items;
    }
}
