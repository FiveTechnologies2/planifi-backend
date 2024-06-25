namespace Planifi_backend.Workers.Domain.Model.ValueObjects;

public class WorkerInfo
{
    public string Position { get; private set; }
    public string WorkedHours { get; private set; }
    public string ExtraHours { get; private set; }
    public string Performance { get; private set; }
    
    public WorkerInfo() { }
    
    public WorkerInfo(string position, string workedHours, string extraHours, string performance)
    {
        Position = position;
        WorkedHours = workedHours;
        ExtraHours = extraHours;
        Performance = performance;
    }
}