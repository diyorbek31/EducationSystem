using EducationSystem.Domain.Enities;

namespace EducationSystem.Service.Integration;

public interface IEdcomUserService
{
    public Task<List<EdcomUser>> GetEdcomUserAsync(string token);
}
