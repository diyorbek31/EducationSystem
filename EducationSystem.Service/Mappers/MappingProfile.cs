using AutoMapper;
using EducationSystem.Domain.Authorization;
using EducationSystem.Domain.Enities;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.DTOs.PermissionContracts;
using EducationSystem.Service.DTOs.RoleContracts;
using EducationSystem.Service.DTOs.UserContracts;

namespace EducationSystem.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User,UserForCreationDto>().ReverseMap();
        CreateMap<User,UserForResultDto>().ReverseMap();
        CreateMap<User,UserForUpdateDto>().ReverseMap();
        CreateMap<Group,GroupForCreationDto>().ReverseMap();
        CreateMap<Group,GroupForResultDto>().ReverseMap();
        CreateMap<Group,GroupForUpdateDto>().ReverseMap();
        CreateMap<Role, RoleForCreationDto>().ReverseMap();
        CreateMap<Role,RoleForResultDto>().ReverseMap();
        CreateMap<Role,GroupForUpdateDto>().ReverseMap();
        CreateMap<Permission,PermissionForResultDto>().ReverseMap();
    }
}
