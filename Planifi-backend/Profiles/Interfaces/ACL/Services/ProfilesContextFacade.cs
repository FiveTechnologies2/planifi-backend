using Planifi_backend.IAM.Domain.Model.Commands;
using Planifi_backend.IAM.Domain.Model.Queries;
using Planifi_backend.IAM.Domain.Model.ValueObjects;
using Planifi_backend.Profiles.Domain.Services;

namespace Planifi_backend.Profiles.Interfaces.ACL.Services;

public class ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    public async Task<int> CreateProfile(string firstName, string lastName, string email, string businessName)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, businessName);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }

    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}