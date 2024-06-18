using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.Queries;
using Planifi_backend.Workers.Domain.Repositories;
using Planifi_backend.Workers.Domain.Services;

namespace Planifi_backend.Workers.Application.Internal.QueryServices;

public class WorkerQueryService(IWorkerRepository workerRepository) : IWorkerQueryService
{
    public async Task<IEnumerable<Worker>> Handle(GetAllWorkersQuery query)
    {
        return await workerRepository.ListAsync();
    }

    public async Task<Worker?> Handle(GetWorkerByEmailQuery query)
    {
        return await workerRepository.FindWorkerByEmailAsync(query.email);
    }

    public async Task<Worker?> Handle(GetWorkerByIdQuery query)
    {
        return await workerRepository.FindByIdAsync(query.WorkerId);
    }

    public Task<Worker?> Handle(GetWorkerByNameQuery query)
    {
        return await workerRepository.FindWorkerByNameAsync(query.name);
    }

    public Task<Worker?> Handel(GetWorkerByPositionQuery query)
    {
        return await workerRepository.FindWorkerByPositionAsync(query.Position);
    }
}