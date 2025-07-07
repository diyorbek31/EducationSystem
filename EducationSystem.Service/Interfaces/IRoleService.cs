using EducationSystem.Service.DTOs.RoleContracts;

namespace EducationSystem.Service.Interfaces;

public interface IRoleService
{
    Task<RoleForResultDto> CreateAsync(RoleForCreationDto role);

    Task<IEnumerable<RoleForResultDto>> RetrieveAllAsync();

    Task<RoleForResultDto> RetrieveByIdAsync(long roleId);

    Task<RoleForResultDto> UpdateAsync(RoleForUpdateDto role);
    Task<bool> RemoveAsync(long roleId);
}
