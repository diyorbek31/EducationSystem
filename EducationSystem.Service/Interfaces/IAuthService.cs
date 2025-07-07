using EducationSystem.Service.DTOs.Authorization;
using EducationSystem.Service.DTOs.AuthorizationContracts;
using Npgsql.Replication.PgOutput.Messages;

namespace EducationSystem.Service.Interfaces;

public interface IAuthService
{
    public Task<LoginForResultDto> AuthenticateAsync(LoginDto login) ;
}
