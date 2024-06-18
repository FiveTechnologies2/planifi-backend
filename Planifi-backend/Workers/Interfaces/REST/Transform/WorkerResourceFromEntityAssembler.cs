using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Interfaces.REST.Resources;

namespace Planifi_backend.Workers.Interfaces.REST.Transform;

public static class WorkerResourceFromEntityAssembler
{
    public static WorkerResource ToResourceFromEntity(Worker entity)
    {
        return new WorkerResource(entity.Id, entity.Name, entity.Email, entity.Position);
    }
}