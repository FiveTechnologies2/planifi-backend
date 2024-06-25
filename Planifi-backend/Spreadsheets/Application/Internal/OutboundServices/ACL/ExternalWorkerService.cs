using Planifi_backend.Spreadsheets.Domain.Model.Entities;
using Planifi_backend.Workers.Interfaces.ACL;

namespace Planifi_backend.Spreadsheets.Application.Internal.OutboundServices.ACL;

public class ExternalWorkerService(IWorkersContextFacade workersContextFacade)
{

    public async Task<WorkerIdentifier> FetchWorkerIdByEmail(string email)
    {
        var workerId = await workersContextFacade.FetchWorkerIdByEmail(email);
        if (workerId == 0) return await Task.FromResult<WorkerIdentifier?>(null);
        return new WorkerIdentifier(workerId);
    }
}