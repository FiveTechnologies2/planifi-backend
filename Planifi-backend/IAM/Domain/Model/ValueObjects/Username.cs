namespace Planifi_backend.IAM.Domain.Model.ValueObjects;

public record Username(string Name)
{
    public Username() : this(string.Empty) {}
}