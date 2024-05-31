namespace Planifi_backend.IAM.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string Email, string Username, string Password);