using Planifi_backend.Shared.Domain.Repositories;
using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.ValueObjects;

namespace Planifi_backend.Workers.Domain.Repositories;

public interface IWorkerRepository : IBaseRepository<Worker>
{
    Task<Worker?> FindWorkerByEmailAsync(EmailAddress email);
}
