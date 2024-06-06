namespace Planifi_backend.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Email, string Token);