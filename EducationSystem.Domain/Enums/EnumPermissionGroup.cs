using System.ComponentModel.DataAnnotations;

namespace EducationSystem.Domain.Enums;

public enum EnumPermissionGroup
{
    [Display(Name = "Admin")]
    Users = 1,
    [Display(Name = "Group")]
    Group = 2,
    [Display(Name = "Teacher")]
    Teacher = 3,
    [Display(Name = "Student")]
    Student = 4,
    [Display(Name = "Role")]
    Role = 5
}
