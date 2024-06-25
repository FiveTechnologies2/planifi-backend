namespace Planifi_backend.Workers.Domain.Model.ValueObjects;

public class WorkerName
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public WorkerName()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }
    
    public WorkerName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public string FullName => $"{FirstName} {LastName}";
}