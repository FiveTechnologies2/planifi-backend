using Microsoft.EntityFrameworkCore;
using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Domain.Repositories;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Planifi_backend.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public bool ExistsByEmail(string email)
    {
        return Context.Set<User>().Any(user => user.Email.Equals(email));
    }
}