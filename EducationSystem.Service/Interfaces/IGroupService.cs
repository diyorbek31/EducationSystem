using EducationSystem.Service.DTOs.GroupContracts;
namespace EducationSystem.Service.Interfaces;

public interface IGroupService
{
    public Task<GroupForResultDto> CreateAsync(GroupForCreationDto dto);
    public Task<GroupForResultDto> UpdateAsync(GroupForUpdateDto groupForUpdateDto);
    public Task<bool> RemoveAsync(long id);
    public Task<GroupForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<GroupForResultDto>> RetrieveAllAsync();
}
