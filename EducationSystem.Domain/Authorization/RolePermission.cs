using EducationSystem.Domain.Commons;

namespace EducationSystem.Domain.Authorization;

public class RolePermission : Auditable
{
    public long RoleId {  get; set; }
    public Role Role { get; set; }
    public long PermissionId {  get; set; }
    public Permission Permission { get; set; }
}
