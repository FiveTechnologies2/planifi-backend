using Planifi_backend.Shared.Domain.Repositories;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Planifi_backend.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}