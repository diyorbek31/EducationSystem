using EducationSystem.Domain.Commons;

namespace EducationSystem.Domain.Authorization;

public class Permission : Auditable
{
    public string Name { get; set; }
    public List<Role> Roles { get; set; } = new();
    public bool IsSystemDefined { get; set; } = false;
}
