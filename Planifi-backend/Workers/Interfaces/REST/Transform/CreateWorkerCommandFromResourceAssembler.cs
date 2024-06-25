using Planifi_backend.Workers.Domain.Model.Commands;
using Planifi_backend.Workers.Interfaces.REST.Resources;

namespace Planifi_backend.Workers.Interfaces.REST.Transform;

public static class CreateWorkerCommandFromResourceAssembler
{
    public static CreateWorkerCommand ToCommandFromResource(CreateWorkerResource resource)
    {
        return new CreateWorkerCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.Phone,
            resource.Address,
            resource.Position,
            resource.WorkedHours,
            resource.ExtraHours,
            resource.Performance
        );
    }
}
