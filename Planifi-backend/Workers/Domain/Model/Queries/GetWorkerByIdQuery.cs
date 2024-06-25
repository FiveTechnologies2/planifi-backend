using System;

namespace Planifi_backend.Workers.Domain.Model.Queries
{
    public class GetWorkerByIdQuery
    {
        public int WorkerId { get; set; }

        public GetWorkerByIdQuery(int workerId)
        {
            WorkerId = workerId;
        }
    }
}