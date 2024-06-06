using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Domain.Model.Queries;
using Planifi_backend.IAM.Domain.Repositories;
using Planifi_backend.Profiles.Domain.Services;

namespace Planifi_backend.IAM.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Profile?> Handle(GetProfileByEmailQuery query)
    {
        return await profileRepository.FindProfileByEmailAsync(query.Email);
    }
    
    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.ProfileId);
    }
}