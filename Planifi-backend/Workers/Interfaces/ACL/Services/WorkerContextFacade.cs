namespace Planifi_backend.Workers.Interfaces.ACL;

public interface IWorkersContextFacade
{
    Task<int> CreateWorker(string Name, string Email, string Phone, string Address,
        string Position, int WorkedHours, int ExtraHours, string Performance);

    Task<int> FetchWorkerIdByEmail(string email);
    
}
