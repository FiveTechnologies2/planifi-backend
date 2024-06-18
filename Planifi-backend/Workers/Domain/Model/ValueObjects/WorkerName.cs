namespace Planifi_backend.Workers.Domain.Model.ValueObjects;

public record WorkerName(string FirstName, string LastName)
{
    public WorkerName() : this(string.Empty, string.Empty) {}

    public WorkerName(string firstName) : this(firstName, string.Empty) {}

    public string FullName => $"{FirstName} {LastName}";
}