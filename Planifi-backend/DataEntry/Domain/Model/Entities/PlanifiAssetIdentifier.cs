namespace Planifi_backend.DataEntry.Domain.Model.Entities;

public record PlanifiAssetIdentifier(Guid Identifier)
{
    public PlanifiAssetIdentifier() : this(Guid.NewGuid()) {}
}