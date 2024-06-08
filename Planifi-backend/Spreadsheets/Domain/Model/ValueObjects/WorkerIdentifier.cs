namespace Planifi_backend.Spreadsheets.Domain.Model.Entities;

public record WorkerIdentifier(Guid Identifier)
{
    public WorkerIdentifier() : this(Guid.NewGuid()) { }
}