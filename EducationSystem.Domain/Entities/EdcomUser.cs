using EducationSystem.Domain.Enums;

namespace EducationSystem.Domain.Enities;

public class EdcomUser
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Phone { get; set; }
    public string? Pinfl { get; set; }
    public List<int> Roles { get; set; } = new();
    public string? Username { get; set; }
    public Language Language { get; set; }
    public UserStatus Status { get; set; }
    public string? BirthDate { get; set; }
    public string? Passport { get; set; }
    public string? BirthPlace { get; set; }
    public string? TemporaryAddress { get; set; }
    public string? Photo { get; set; }
    public List<int> Permissions { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}
