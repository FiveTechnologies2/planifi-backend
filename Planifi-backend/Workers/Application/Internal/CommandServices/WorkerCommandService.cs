using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.Commands;
using Planifi_backend.Workers.Domain.Repositories;
using Planifi_backend.Workers.Domain.Services;
using Planifi_backend.Shared.Domain.Repositories;

namespace Planifi_backend.Workers.Application.Internal.CommandServices;

public class WorkerCommandService(IWorkerRepository workerRepository, IUnitOfWork unitOfWork) : IWorkerCommandService
{
    public async Task<Worker?> Handle(CreateWorkerCommand command)
    {
        var worker = new Worker(command);
        try
        {
            await workerRepository.AddAsync(worker);
            await unitOfWork.CompleteAsync();
            return worker;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error ocurred while creating the worker: {e.Message}");
            return null;
        }
    }
}