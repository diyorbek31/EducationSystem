using EducationSystem.Domain.Authorization;

namespace EducationSystem.Service.DTOs.RoleContracts;

public class RoleForUpdateDto
{
    public long Id { get; set; }
    public string Name {  get; set; }
    public List<long> Permissions {  get; set; }
}
