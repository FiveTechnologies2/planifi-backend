namespace Planifi_backend.Workers.Interfaces.REST.Resources;

public record CreateWorkerResource(string Name, string Email, string Phone, string Address,
    string Position, int WorkedHours, int ExtraHours, string Performance);
