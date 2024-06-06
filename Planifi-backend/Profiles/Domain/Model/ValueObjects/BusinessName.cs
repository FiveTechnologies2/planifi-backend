namespace Planifi_backend.IAM.Domain.Model.ValueObjects;

public record BusinessName(string businessName)
{
    public BusinessName() : this(string.Empty) {}
}