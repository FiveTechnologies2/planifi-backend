namespace Planifi_backend.Workers.Interfaces.ACL;

public interface IWorkersContextFacade
{
    Task<int> CreateWorker(string firstName, string lastName, string email, string phone, string address, string position, string workedHours, string extraHours, string performance);

    Task<int> FetchWorkerIdByEmail(string email);
}