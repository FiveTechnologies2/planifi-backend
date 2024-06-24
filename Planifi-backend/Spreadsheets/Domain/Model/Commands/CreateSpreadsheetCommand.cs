using Planifi_backend.Spreadsheets.Domain.Model.ValueObjects;

namespace Planifi_backend.Spreadsheets.Domain.Model.Commands;

public record CreateSpreadsheetCommand(string Name, string Description, int CompanyId);