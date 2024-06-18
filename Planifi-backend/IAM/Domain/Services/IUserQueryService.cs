using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Domain.Model.Queries;

namespace Planifi_backend.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByEmailQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}