namespace Planifi_backend.Workers.Domain.Model.ValueObjects;

public record WorkerName(string Name)
{
    public WorkerName() : this(String.Empty) {}
}