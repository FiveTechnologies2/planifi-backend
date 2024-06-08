using Microsoft.EntityFrameworkCore;
using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.ValueObjects;
using Planifi_backend.Workers.Domain.Repositories;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Planifi_backend.Workers.Infrastructure.Persistence.EFC.Repositories;

public class WorkerRepository(AppDbContext context) : BaseRepository<Worker>(context), IWorkerRepository
{
    public Task<Worker?> FindWorkerByEmailAsync(EmailAddress email)
    {
        return context.Set<Worker>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }
}
