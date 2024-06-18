namespace Planifi_backend.Spreadsheets.Interfaces.REST.Resources;

public record CreateSpreadsheetResource(string Name, string Description, int CompanyId);