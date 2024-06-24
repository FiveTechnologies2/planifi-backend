namespace Planifi_backend.IAM.Domain.Model.ValueObjects;

public record Password(string Passwords)
{
    public Password() : this(string.Empty) {}
    
}