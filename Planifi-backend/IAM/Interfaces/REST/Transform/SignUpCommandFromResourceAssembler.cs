using Planifi_backend.IAM.Domain.Model.Commands;
using Planifi_backend.IAM.Interfaces.REST.Resources;

namespace Planifi_backend.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Email, resource.Password);
    }
}