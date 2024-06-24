using Planifi_backend.Spreadsheets.Domain.Model.Aggregates;
using Planifi_backend.Spreadsheets.Domain.Model.Commands;

namespace Planifi_backend.Spreadsheets.Domain.Services;

public interface ISpreadsheetCommandService
{
    Task<Spreadsheet?> Handle(CreateSpreadsheetCommand command);
}