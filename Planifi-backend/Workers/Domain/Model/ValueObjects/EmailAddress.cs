namespace Planifi_backend.Workers.Domain.Model.ValueObjects
{
    public class EmailAddress
    {
        public string Value { get; set; }

        public EmailAddress(string value)
        {
            Value = value;
        }
    }
}
