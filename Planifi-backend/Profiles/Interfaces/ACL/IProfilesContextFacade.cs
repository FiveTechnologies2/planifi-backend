namespace Planifi_backend.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string email, string businessName);

    Task<int> FetchProfileIdByEmail(string email);
}