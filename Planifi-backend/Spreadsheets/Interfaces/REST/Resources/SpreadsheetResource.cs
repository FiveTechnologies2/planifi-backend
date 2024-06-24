using Planifi_backend.Spreadsheets.Domain.Model.ValueObjects;

namespace Planifi_backend.Spreadsheets.Interfaces.REST.Resources;

public record SpreadsheetResource(int Id, string Name, string Description, CompanyId CompanyId);