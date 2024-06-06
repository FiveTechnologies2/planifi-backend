using Planifi_backend.IAM.Domain.Model.Aggregates;
using Planifi_backend.IAM.Domain.Model.Commands;
using Planifi_backend.IAM.Domain.Repositories;
using Planifi_backend.Profiles.Domain.Services;
using Planifi_backend.Shared.Domain.Repositories;

namespace Planifi_backend.IAM.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}