using Planifi_backend.Workers.Domain.Model.Commands;
using Planifi_backend.Workers.Domain.Model.ValueObjects;

namespace Planifi_backend.Workers.Domain.Model.Aggregates
{
    public partial class Worker
    {
        public Worker()
        {
            Name = new WorkerName();
            Email = new EmailAddress();
            Position = new WorkerPosition();
        }

        public Worker(string name, string email, string phone, string address, string position, string workedHours,
            string extraHours, string performance)
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

        public Worker(CreateWorkerCommand command)
        {
            Name = new WorkerName(command.Name);
            Email = new EmailAddress(command.Email);
            Position = new WorkerPosition(command.Position);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int WorkedHours { get; set; }
        public int ExtraHours { get; set; }
        public string Performance { get; set; }
    }
}
