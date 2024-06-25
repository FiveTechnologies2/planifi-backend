using Microsoft.EntityFrameworkCore;
using Planifi_backend.Workers.Domain.Model.Aggregates;
using Planifi_backend.Workers.Domain.Model.ValueObjects;
using Planifi_backend.Workers.Domain.Repositories;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Planifi_backend.Workers.Infrastructure.Persistence.EFC.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Worker?> FindWorkerByEmailAsync(EmailAddress email)
        {
            return Context.Set<Worker>().Where(w => w.Email == email).FirstOrDefaultAsync();
        }

        public Task<Worker?> FindWorkerByIdAsync(int id)
        {
            return Context.Set<Worker>().Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Worker>> GetWorkersByPositionAsync(string position)
        {
            var workers = await Context.Set<Worker>().Where(w => w.WorkInformation.Position == position).ToListAsync();
            return workers.AsEnumerable();
        }

        public Task<Worker?> GetWorkerByEmailAsync(string email)
        {
            return Context.Set<Worker>().Where(w => w.Email.Value == email).FirstOrDefaultAsync();
        }

        public void Update(Worker worker)
        {
            Context.Entry(worker).State = EntityState.Modified;
        }
    }
}
