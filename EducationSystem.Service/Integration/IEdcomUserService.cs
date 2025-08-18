using EducationSystem.Domain.Enities;

namespace EducationSystem.Service.Integration;

public interface IEdcomUserService
{
    Task<List<EdcomUser>> GetEdcomUserAsync();
}
