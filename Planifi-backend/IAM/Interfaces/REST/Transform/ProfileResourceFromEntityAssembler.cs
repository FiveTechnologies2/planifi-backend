using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Interfaces.REST.Resources;

namespace Planifi_backend.IAM.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress, entity.businessName);
    }
}