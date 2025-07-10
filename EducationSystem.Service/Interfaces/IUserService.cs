using EducationSystem.Domain.Congirations;
using EducationSystem.Domain.Enities;
using EducationSystem.Service.DTOs.UserContracts;

namespace EducationSystem.Service.Interfaces;

public interface IUserService
{
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    public Task<UserForResultDto> UpdateAsync(long id,UserForUpdateDto userForUpdate);
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    public Task<User> RetrieveByEmailAsync(string email);
}
