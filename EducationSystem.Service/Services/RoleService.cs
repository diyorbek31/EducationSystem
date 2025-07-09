using AutoMapper;
using EducationSystem.Data.DbContexts;
using EducationSystem.Data.IRepositories;
using EducationSystem.Domain.Authorization;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.DTOs.RoleContracts;
using EducationSystem.Service.Exceptions;
using EducationSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Service.Services;

public class RoleService(
    IMapper mapper,
    IRepository<Role> roleRepository,
    AppDbContext dbContext): IRoleService
{
    public async Task<RoleForResultDto> CreateAsync(RoleForCreationDto dto)
    {
        var role = await roleRepository.SelectAll()
            .FirstOrDefaultAsync(r => r.Name.ToLower() == dto.Name.ToLower());
        if (role is not null)
            throw new CustomException(404, "Role is already exists");
        role = new Role
        {
            Name = dto.Name,
        };
        //foreach(var permissionId in  dto.Permissions)
        //{
        //    var permission = new Permission { Id = permissionId };
        //    dbContext.Permissions.Add(permission);
        //    role.Permissions.Add(permission);
        //}
        dbContext.Roles.Add(role);  
        await dbContext.SaveChangesAsync();
        return mapper.Map<RoleForResultDto>(role);
    }
    
    public async Task<bool> RemoveAsync(long roleId)
    {
        var role = await roleRepository.SelectByIdAsync(roleId);
        if (role is null)
            throw new CustomException(404, "Group is not found");
        await roleRepository.DeleteAsync(roleId);
        await roleRepository.SaveChangeAsync();
        return true;
    }

    public async Task<IEnumerable<RoleForResultDto>> RetrieveAllAsync()
    {
        var roles = await roleRepository.SelectAll().ToListAsync();

        return mapper.Map<IEnumerable<RoleForResultDto>>(roles);
    }

    public async Task<RoleForResultDto> RetrieveByIdAsync(long id)
    {
        var role = await roleRepository.SelectByIdAsync(id);
        if (role is null)
            throw new CustomException(404, "Role is not found");

        return mapper.Map<RoleForResultDto>(role);
    }

    public async Task<Role> RetrieveByIdForAuthAsync(long id)
        => await roleRepository.SelectAll()
            .FirstOrDefaultAsync(r => r.Id == id) 
            ?? throw new CustomException(404, "Role is not found for authentication");

    public async Task<RoleForResultDto> UpdateAsync(RoleForUpdateDto dto)
    {
        var role = await roleRepository.SelectAll()
            .FirstOrDefaultAsync(r => r.Id == dto.Id);
        if (role is null)
            throw new CustomException(404, "Role is not found");

        role.Name = dto.Name;
        role.UpdatedAt = DateTime.Now;

        //role.Permissions.Clear();

        //foreach (var permissionId in dto.Permissions)
        //{
        //    var permission = new Permission { Id = permissionId };
        //    dbContext.Attach(permission); // Attach to avoid duplicate insert
        //    role.Permissions.Add(permission);
        //}

        dbContext.Roles.Update(role);
        await dbContext.SaveChangesAsync();

        return mapper.Map<RoleForResultDto>(role);
    }
}
