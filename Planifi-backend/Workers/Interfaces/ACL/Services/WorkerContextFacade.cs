using Planifi_backend.Workers.Domain.Model.Commands;
using Planifi_backend.Workers.Domain.Model.Queries;
using Planifi_backend.Workers.Domain.Model.ValueObjects;
using Planifi_backend.Workers.Domain.Services;

namespace Planifi_backend.Workers.Interfaces.ACL.Services;

public class WorkersContextFacade : IWorkersContextFacade
{
    private readonly IWorkerCommandService _workerCommandService;
    private readonly IWorkerQueryService _workerQueryService;

    public WorkersContextFacade(IWorkerCommandService workerCommandService, IWorkerQueryService workerQueryService)
    {
        _workerCommandService = workerCommandService;
        _workerQueryService = workerQueryService;
    }

    public async Task<int> CreateWorker(string firstName, string lastName, string email, string phone, string address, string position, string workedHours, string extraHours, string performance)
    {
        var createWorkerCommand = new CreateWorkerCommand(firstName, lastName, email, phone, address, position, workedHours, extraHours, performance);
        var worker = await _workerCommandService.Handle(createWorkerCommand);
        return worker?.Id ?? 0;
    }

    public async Task<int> FetchWorkerIdByEmail(string email)
    {
        var getWorkerByEmailQuery = new GetWorkerByEmailQuery(new EmailAddress(email));
        var worker = await _workerQueryService.Handle(getWorkerByEmailQuery);
        return worker?.Id ?? 0;
    }
}
