namespace Planifi_backend.Workers.Interfaces.REST.Resources;

public record CreateWorkerResource(string FirstName, string LastName, string Email, string Phone, string Address, string Position, string WorkedHours, string ExtraHours, string Performance);
