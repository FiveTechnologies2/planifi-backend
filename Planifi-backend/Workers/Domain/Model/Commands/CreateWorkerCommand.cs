namespace Planifi_backend.Workers.Domain.Model.Commands
{
    public record CreateWorkerCommand(string Name, string Email, string Phone, string Address,
        string Position, int WorkedHours, int ExtraHours, string Performance);
}
