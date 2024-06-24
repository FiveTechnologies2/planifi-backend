namespace Planifi_backend.Workers.Domain.Model.Commands
{
    public record CreateWorkerCommand(string FirstName, string LastName, string Email, string Phone, string Address,
        string Position, string WorkedHours, string ExtraHours, string Performance);
}
