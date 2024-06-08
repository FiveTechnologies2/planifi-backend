using Planifi_backend.Spreadsheets.Domain.Model.ValueObjects;

namespace Planifi_backend.Spreadsheets.Domain.Model.Entities;

public partial class Worker
{
    public int Id { get; }
    
    public WorkerIdentifier WorkerIdentifier { get; private set; }
    
    public WorkerName WorkerName { get; private set; }
    
    public EmailAddress EmailAddress { get; private set; }
    
    public StreetAddress StreetAddress { get; private set; }
    
    public EWorkerPosition Position { get; private set; }

    public Worker(EWorkerPosition position)
    {
        Position = position;
        WorkerIdentifier = new WorkerIdentifier();
    }
    
}