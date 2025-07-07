using System.ComponentModel;

namespace EducationSystem.Domain.Enums;

public enum EnumPermission
{
    [Category(nameof(EnumPermissionGroup.Users))]
    CreateUser = 101,
    ViewUser,
    EditUser,
    DeleteUser,

    [Category(nameof(EnumPermissionGroup.Group))]
    CreateGroup = 201,
    ViewGroup,
    EditGroup,
    DeleteGroup,

    [Category(nameof(EnumPermissionGroup.Teacher))]
    CreateTeacher = 301,
    ViewTeacher,
    EditTeacher,
    DeleteTeacher,

    [Category(nameof(EnumPermissionGroup.Student))]
    CreateStudent = 401,
    ViewStudent,
    EditStudent,
    DeleteStudent,

    [Category(nameof(EnumPermissionGroup.Role))]
    CreateRole = 501,
    ViewRole,
    EditRole,
    DeleteRole,

}
 