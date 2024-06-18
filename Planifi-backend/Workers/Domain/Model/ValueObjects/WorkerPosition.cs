namespace Planifi_backend.Workers.Domain.Model.ValueObjects;

public record WorkerPosition (string Position)
{
    public WorkerPosition() : this(String.Empty) {}
}
