using Planifi_backend.IAM.Domain.Model.ValueObjects;

namespace Planifi_backend.IAM.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);