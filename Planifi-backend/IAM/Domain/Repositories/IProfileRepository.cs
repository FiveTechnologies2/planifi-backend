using Planifi_backend.Shared.Domain.Repositories;
using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Domain.Model.ValueObjects;

namespace Planifi_backend.IAM.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}