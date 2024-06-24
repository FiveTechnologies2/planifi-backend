using Planifi_backend.Workers.Domain.Model.Commands;
using Planifi_backend.Workers.Domain.Model.Queries;
using Planifi_backend.Workers.Domain.Model.ValueObjects;
using Planifi_backend.Workers.Domain.Services;

namespace Planifi_backend.Workers.Interfaces.ACL.Services;

public class WorkerContextFacade(IWorkerCommandService workerCommandService, IWorkerQueryService workerQueryService) : IWorkersContextFacade
{
    public Task<int> CreateWorker(string Name, string Email, string Phone, string Address, string Position, int WorkedHours,
        int ExtraHours, string Performance)
    {
        var createWorkerCommand = new CreateWorkerCommand(Name, Email, Phone, Address, Position, Position, WorkedHours,
            ExtraHours, Performance);
        var worker = await workerCommandService.Handle(createWorkerCommand);
        return worker?.Id ?? 0;
    }

    public async Task<int> FetchWorkerIdByEmail(string email)
    {
        var getWorkerByEmailQuery = new GetWorkerByEmailQuery(new EmailAddress(email));
        var worker = await workerQueryService.Handle(getWorkerByEmailQuery);
        return worker?.Id ?? 0;
    }
}
