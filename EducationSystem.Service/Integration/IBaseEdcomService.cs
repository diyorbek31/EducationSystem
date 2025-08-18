using EducationSystem.Service.DTOs.EdcomDto;

namespace EducationSystem.Service.Integration;

public interface IBaseEdcomService
{
    Task InitializeAsync(LoginRequest request);
}
