using Planifi_backend.IAM.Domain.Model.Commands;
using Planifi_backend.IAM.Domain.Model.ValueObjects;

namespace Planifi_backend.IAM.Domain.Model.Aggregates;

public partial class Profile
{
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Username = new Username();
        Password = new Password();
    }

    public Profile(string firstName, string lastName, string email, string username, string password)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Username = new Username(username);
        Password = new Password(password);
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Username = new Username(command.Username);
        Password = new Password(command.Password);
    }

    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public Username Username { get; private set; }
    public Password Password { get; private set; }

    public string FullName => Name.FullName;

    public string EmailAddress => Email.Address;

    public string UserName => Username.Name;
    public string Passwords => Password.Passwords;
}