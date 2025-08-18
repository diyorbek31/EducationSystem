using EducationSystem.Integration.Requests;

namespace EducationSystem.Integration.BaseIntegration;

public interface IBaseIntegrationService
{
    Task InitiliazeAsync(LoginRequest request);
}
