using Planifi_backend.Workers.Domain.Model.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planifi_backend.Workers.Domain.Repositories
{
    public interface IWorkerRepository
    {
        Task AddAsync(Worker worker);
        Task<Worker?> FindByIdAsync(int id);
        Task<IEnumerable<Worker>> ListAsync();
        Task<IEnumerable<Worker>> GetWorkersByPositionAsync(string position);
        Task<Worker?> GetWorkerByEmailAsync(string email);
        void Update(Worker worker);
    }
}
