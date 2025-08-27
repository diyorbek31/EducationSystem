using EducationSystem.Domain.Authorization;
using EducationSystem.Domain.Commons;
using EducationSystem.Domain.Enums;
using System.Text.RegularExpressions;

namespace EducationSystem.Domain.Enities;

public class User : Auditable
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName {  get; set; }
    public string Password { get; set; }
    public long GroupId {  get; set; }
    public Group Group { get; set; }
    public long RoleId {  get; set; }
    public Role Role { get; set; }
}
