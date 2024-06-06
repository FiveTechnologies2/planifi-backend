using Microsoft.EntityFrameworkCore;
using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Domain.Model.ValueObjects;
using Planifi_backend.IAM.Domain.Repositories;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Planifi_backend.IAM.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }
}