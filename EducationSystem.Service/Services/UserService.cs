using AutoMapper;
using EducationSystem.Data.IRepositories;
using EducationSystem.Domain.Congirations;
using EducationSystem.Domain.Enities;
using EducationSystem.Service.DTOs.UserContracts;
using EducationSystem.Service.Exceptions;
using EducationSystem.Service.Extentions;
using EducationSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace EducationSystem.Service.Services;
public class UserService (
    IMapper mapper,
    IRepository<User> userRepository): IUserService
{
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = await userRepository.SelectAll().
            FirstOrDefaultAsync(u => u.FirstName.ToLower() == dto.FirstName.ToLower());
        if (user is not null)
            throw new CustomException(409, "User already exists");

        var mappedUser = mapper.Map<User>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;
        var result = await userRepository.InsertAsync(mappedUser);
        await userRepository.SaveChangeAsync();

        return mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await    userRepository.SelectByIdAsync(id);
        if (user is null)
            throw new CustomException(404, "User is not found");
        await userRepository.DeleteAsync(id);
        await userRepository.SaveChangeAsync();
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await userRepository
            .SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<User> RetrieveByEmailAsync(string email)
    {
        var user = await userRepository.SelectAll()
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

        if (user is null)
            throw new CustomException(404, "User is not found");

        return user; 
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var user = await userRepository.SelectByIdAsync(id);
        if (user is null)
            throw new CustomException(404, "User is not found");

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateAsync(long id ,UserForUpdateDto dto)
    {
        var user = await userRepository.SelectByIdAsync(id);
        if (user is null)
            throw new CustomException(404, "User is not found");

        mapper.Map(dto, user);
        user.UpdatedAt = DateTime.Now;
        await userRepository.UpdateAsync(user);
        await userRepository.SaveChangeAsync();

        return mapper.Map<UserForResultDto>(user);
    }
}
