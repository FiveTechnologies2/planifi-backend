using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.Commands;

namespace Planifi_backend.Workers.Domain.Services;

public interface IWorkerCommandService
{
    Task<Worker?> Handle(CreateWorkerCommand command);
}