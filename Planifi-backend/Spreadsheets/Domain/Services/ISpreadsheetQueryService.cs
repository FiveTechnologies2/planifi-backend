using Planifi_backend.Spreadsheets.Domain.Model.Aggregates;
using Planifi_backend.Spreadsheets.Domain.Model.Queries;

namespace Planifi_backend.Spreadsheets.Domain.Services;

public interface ISpreadsheetQueryService
{
    Task<IEnumerable<Spreadsheet>> Handle(GetAllSpreadsheetsQuery query);
    Task<Spreadsheet?> Handle(GetSpreadsheetByIdQuery query);
    Task<Spreadsheet?> Handle(GetSpreadsheetByNameQuery query);
}