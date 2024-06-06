using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Interfaces.REST.Resources;

namespace Planifi_backend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Email, token);
    }
}