﻿namespace EducationSystem.Service.DTOs.UserContracts;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName {  get; set; }
    public long GroupId {  get; set; }
    public long RoleId {  get; set; }
}
