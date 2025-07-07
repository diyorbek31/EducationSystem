using AutoMapper;
using EducationSystem.Data.IRepositories;
using EducationSystem.Domain.Authorization;
using EducationSystem.Service.DTOs.PermissionContracts;
using EducationSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace EducationSystem.Service.Services;

public class PermissionService(
    IRepository<Permission> repository,
    IMapper mapper): IPermissionService
{
    public async Task<PermissionForResultDto> GetAllPermissionsAsync()
    {
        var permissions = await repository
            .SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<PermissionForResultDto>(permissions);
    }
}
