namespace EducationSystem.Service.DTOs.UserContracts;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public long GroupId { get; set; }
    public long RoleId { get; set; }
}
