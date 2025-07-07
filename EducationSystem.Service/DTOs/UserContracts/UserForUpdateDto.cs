namespace EducationSystem.Service.DTOs.UserContracts;

public class UserForUpdateDto
{
    public long Id {  get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
