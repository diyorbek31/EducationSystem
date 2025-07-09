using EducationSystem.Domain.Commons;
using EducationSystem.Domain.Enities;

namespace EducationSystem.Domain.Authorization;

public class Role : Auditable
{
    public string Name {  get; set; }
    //public ICollection<User> Users { get; set; }
    //public List<Permission> Permissions { get; set; }
}
