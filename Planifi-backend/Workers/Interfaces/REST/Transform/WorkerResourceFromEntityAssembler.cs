using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Interfaces.REST.Resources;

namespace Planifi_backend.Workers.Interfaces.REST.Transform;

public static class WorkerResourceFromEntityAssembler
{
    public static WorkerResource ToResourceFromEntity(Worker entity)
    {
        return new WorkerResource(
            entity.Id,
            entity.Name.FirstName,
            entity.Name.LastName,
            entity.Email.Value,
            entity.Phone,
            entity.Address,
            entity.WorkInformation.Position,
            entity.WorkInformation.WorkedHours,
            entity.WorkInformation.ExtraHours,
            entity.WorkInformation.Performance
        );
    }
}