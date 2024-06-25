using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.Commands;
using Planifi_backend.Workers.Domain.Repositories;
using Planifi_backend.Workers.Domain.Services;
using Planifi_backend.Shared.Domain.Repositories;
using System;

namespace Planifi_backend.Workers.Application.Internal.CommandServices
{
    public class WorkerCommandService : IWorkerCommandService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorkerCommandService(IWorkerRepository workerRepository, IUnitOfWork unitOfWork)
        {
            _workerRepository = workerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Worker?> Handle(CreateWorkerCommand command)
        {
            var worker = new Worker(command);
            try
            {
                await _workerRepository.AddAsync(worker);
                await _unitOfWork.CompleteAsync();
                return worker;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the worker: {e.Message}");
                return null;
            }
        }

        public async Task<Worker?> Handle(UpdateWorkerCommand command)
        {
            var worker = await _workerRepository.FindByIdAsync(command.Id);
            if (worker == null) return null;

            worker.Update(command);
            try
            {
                _workerRepository.Update(worker);
                await _unitOfWork.CompleteAsync();
                return worker;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while updating the worker: {e.Message}");
                return null;
            }
        }
    }
}
