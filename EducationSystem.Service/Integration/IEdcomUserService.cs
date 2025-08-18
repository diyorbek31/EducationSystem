using EducationSystem.Domain.Enities;
using EducationSystem.Service.DTOs.EdcomDto;

namespace EducationSystem.Service.Integration;

public interface IEdcomUserService
{
    Task<List<EdcomUser>> GetAllEdcomUsersAsync(LoginRequest request);
    Task<EdcomUser> GetEdcomUserAsync(long id, LoginRequest request);
}
