using Planifi_backend.Workers.Domain.Model.ValueObjects;

namespace Planifi_backend.Workers.Domain.Model.Queries;

public record GetWorkerByEmailQuery(EmailAddress email);