using Planifi_backend.IAM.Domain.Model.Commands;
using Planifi_backend.IAM.Domain.Model.ValueObjects;

namespace Planifi_backend.IAM.Domain.Model.Aggregates;

public partial class Profile
{
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Business = new BusinessName();
    }

    public Profile(string firstName, string lastName, string email, string businessName)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Business = new BusinessName(businessName);
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Business = new BusinessName(command.Business);
    }

    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public BusinessName Business { get; private set; }

    public string FullName => Name.FullName;

    public string EmailAddress => Email.Address;

    public string businessName => Business.businessName;
}