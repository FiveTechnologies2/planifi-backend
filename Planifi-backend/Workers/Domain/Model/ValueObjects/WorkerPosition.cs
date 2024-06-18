namespace Planifi_backend.Workers.Domain.Model.ValueObjects;

public record WorkerInfo (string Position, string WorkedHours, string ExtraHours, string Performance)
{
    public WorkerInfo() : this(string.Empty, string.Empty, string.Empty, string.Empty) {}
}
