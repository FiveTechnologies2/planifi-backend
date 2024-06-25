using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.Queries;
using Planifi_backend.Workers.Domain.Repositories;
using Planifi_backend.Workers.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planifi_backend.Workers.Application.Internal.QueryServices
{
    public class WorkerQueryService : IWorkerQueryService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerQueryService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<IEnumerable<Worker>> Handle(GetAllWorkersQuery query)
        {
            return await _workerRepository.ListAsync();
        }

        public async Task<Worker?> Handle(GetWorkerByIdQuery query)
        {
            return await _workerRepository.FindByIdAsync(query.WorkerId);
        }

        public async Task<IEnumerable<Worker>> Handle(GetWorkersByPositionQuery query)
        {
            return await _workerRepository.GetWorkersByPositionAsync(query.Position);
        }

        public async Task<Worker?> Handle(GetWorkerByEmailQuery query)
        {
            return await _workerRepository.GetWorkerByEmailAsync(query.Email.Value);
        }
    }
}
