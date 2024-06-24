using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.Shared.Domain.Repositories;

namespace Planifi_backend.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
}