using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.Queries;

namespace Planifi_backend.Workers.Domain.Services;

public interface IWorkerQueryService
{
    Task<IEnumerable<Worker>> Handle(GetAllWorkersQuery query);
    Task<Worker?> Handle(GetWorkerByEmailQuery query);
    Task<Worker?> Handle(GetWorkerByIdQuery query);
    Task<Worker?> Handle(GetWorkerByNameQuery query);
    Task<Worker?> Handel(GetWorkerByPositionQuery query);
}
