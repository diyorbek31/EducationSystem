using EducationSystem.Service.DTOs.PermissionContracts;

namespace EducationSystem.Service.Interfaces;

public interface IPermissionService
{
    public Task<PermissionForResultDto> GetAllPermissionsAsync();
}
