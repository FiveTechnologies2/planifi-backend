using Planifi_backend.Workers.Domain.Model.Commands;
using Planifi_backend.Workers.Domain.Model.ValueObjects;
using EmailAddress = Planifi_backend.Workers.Domain.Model.ValueObjects.EmailAddress;
using WorkerName = Planifi_backend.Workers.Domain.Model.ValueObjects.WorkerName;

namespace Planifi_backend.Workers.Domain.Model.Aggregates
{
    public partial class Worker
    {
        public Worker()
        {
            Name = new WorkerName();
            Email = new EmailAddress("default@exple.com");
            WorkInformation = new WorkerInfo();
        }

        public Worker(string firstName, string lastName, string email, string phone, string address, string position,
            string workedHours, string extraHours, string performance)
        {
            Name = new WorkerName(firstName, lastName);
            Email = new EmailAddress(email);
            Phone = phone;
            Address = address;
            WorkInformation = new WorkerInfo(position, workedHours, extraHours, performance);
        }

        public Worker(CreateWorkerCommand command)
        {
            Name = new WorkerName(command.FirstName, command.LastName);
            Email = new EmailAddress(command.Email);
            Phone = command.Phone;
            Address = command.Address;
            WorkInformation = new WorkerInfo(command.Position, command.WorkedHours, command.ExtraHours, command.Performance);
        }

        public Worker(UpdateWorkerCommand command)
        {
            Id = command.Id;
            Name = new WorkerName(command.FirstName, command.LastName);
            Email = new EmailAddress(command.Email);
            Phone = command.Phone;
            Address = command.Address;
            WorkInformation = new WorkerInfo(command.Position, command.WorkedHours, command.ExtraHours, command.Performance);
        }

        public int Id { get; }
        public WorkerName Name { get; private set; }
        public EmailAddress Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public WorkerInfo WorkInformation { get; private set; }

        public string FullName => Name.FullName;

        public void Update(UpdateWorkerCommand command)
        {
            Name = new WorkerName(command.FirstName, command.LastName);
            Email = new EmailAddress(command.Email);
            Phone = command.Phone;
            Address = command.Address;
            WorkInformation = new WorkerInfo(command.Position, command.WorkedHours, command.ExtraHours, command.Performance);
        }
    }
}
