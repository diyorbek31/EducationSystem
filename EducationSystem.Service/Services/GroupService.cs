using AutoMapper;
using EducationSystem.Data.IRepositories;
using EducationSystem.Domain.Enities;
using EducationSystem.Service.DTOs.GroupContracts;
using EducationSystem.Service.DTOs.UserContracts;
using EducationSystem.Service.Exceptions;
using EducationSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Service.Services;

public class GroupService : IGroupService
{
    private readonly IMapper mapper;
    private readonly IRepository<Group> groupRepository;
    public GroupService(IMapper mapper, IRepository<Group> groupRepository)
    {
        this.mapper = mapper;
        this.groupRepository = groupRepository;
    }
    public async Task<GroupForResultDto> CreateAsync(GroupForCreationDto dto)
    {
        var group = await this.groupRepository.SelectAll().
            FirstOrDefaultAsync(u => u.Name.ToLower() == dto.Name.ToLower());
        if (group is not null)
            throw new CustomException(409, "Group already exists");

        var mappedGroup = this.mapper.Map<Group>(dto);
        mappedGroup.CreatedAt = DateTime.UtcNow;
        var result = await this.groupRepository.InsertAsync(mappedGroup);
        await this.groupRepository.SaveChangeAsync();

        return this.mapper.Map<GroupForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var group = await this.groupRepository.SelectByIdAsync(id);
        if (group is null)
            throw new CustomException(404, "Group is not found");
        await this.groupRepository.DeleteAsync(id);
        await this.groupRepository.SaveChangeAsync();
        return true;
    }

    public async Task<IEnumerable<GroupForResultDto>> RetrieveAllAsync()
    {
        var groups = await this.groupRepository.SelectAll().ToListAsync();

        return this.mapper.Map<IEnumerable<GroupForResultDto>>(groups);
    }

    public async Task<GroupForResultDto> RetrieveByIdAsync(long id)
    {
        var group = await this.groupRepository.SelectByIdAsync(id);
        if (group is null)
            throw new CustomException(404, "Group is not found");

        return this.mapper.Map<GroupForResultDto>(group);
    }

    public async Task<GroupForResultDto> UpdateAsync(GroupForUpdateDto dto)
    {
        var group = await this.groupRepository.SelectByIdAsync(dto.Id);
        if (group is null)
            throw new CustomException(404, "Group is not found");


        this.mapper.Map(dto, group);
        group.UpdatedAt = DateTime.Now;
        await this.groupRepository.UpdateAsync(group);
        await this.groupRepository.SaveChangeAsync();

        return this.mapper.Map<GroupForResultDto>(group);
    }
}
