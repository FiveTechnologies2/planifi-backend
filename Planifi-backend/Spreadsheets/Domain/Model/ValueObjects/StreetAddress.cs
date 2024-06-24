namespace Planifi_backend.Spreadsheets.Domain.Model.ValueObjects;

public record StreetAddress(string StreetName, int Number, string PostalCode, string City, string Country);