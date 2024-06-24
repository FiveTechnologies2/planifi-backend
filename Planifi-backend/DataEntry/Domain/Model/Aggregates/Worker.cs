namespace Planifi_backend.DataEntry.Domain.Model.Aggregates;

public partial class Worker
{
    public int Id { get; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Address { get; set; }
    
    public string Position { get; set; }
    
    public int WorkedHours { get; set; }
    
    public int ExtraHours { get; set; }
    
    public string Performance { get; set; }

    public Worker(string name, string email, string phone, string address,
        string position, int workedHours, int extraHours, string performance)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
        Position = position;
        WorkedHours = workedHours;
        ExtraHours = extraHours;
        Performance = performance;
    }
    
    /*
     * public Worker(CreateWorkerCommand command)
     * {
     *  Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        Address = command.Address;
        Position = command.Position;
        WorkedHours = command.WorkedHours;
        ExtraHours = command.ExtraHours;
        Performance = command.Performance;
     * }
     */
}