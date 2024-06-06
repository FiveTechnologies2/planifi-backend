using Planifi_backend.IAM.Domain.Model.Commands;
using Planifi_backend.IAM.Interfaces.REST.Resources;

namespace Planifi_backend.IAM.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email, resource.businessName);
    }
}