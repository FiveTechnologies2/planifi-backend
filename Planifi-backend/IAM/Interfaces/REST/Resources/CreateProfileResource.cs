namespace Planifi_backend.IAM.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName, string LastName, string Email, string businessName);