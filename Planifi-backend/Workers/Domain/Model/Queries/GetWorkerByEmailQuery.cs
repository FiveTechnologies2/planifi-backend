using Planifi_backend.Workers.Domain.Model.ValueObjects;

namespace Planifi_backend.Workers.Domain.Model.Queries
{
    public class GetWorkerByEmailQuery
    {
        public EmailAddress Email { get; set; }

        public GetWorkerByEmailQuery(EmailAddress email)
        {
            Email = email;
        }
    }
}