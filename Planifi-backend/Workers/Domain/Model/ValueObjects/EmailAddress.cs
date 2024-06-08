namespace Planifi_backend.Workers.Domain.Model.ValueObjects;

public record EmailAddress(string Email)
{
    public EmailAddress() : this(String.Empty) {}
}