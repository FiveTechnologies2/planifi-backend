using Planifi_backend.Spreadsheets.Domain.Model.Aggregates;
using Planifi_backend.Spreadsheets.Domain.Model.Queries;
using Planifi_backend.Spreadsheets.Domain.Repositories;
using Planifi_backend.Spreadsheets.Domain.Services;

namespace Planifi_backend.Spreadsheets.Application.Internal.QueryServices;

public class SpreadsheetQueryService(ISpreadsheetRepository spreadsheetRepository) : ISpreadsheetQueryService
{
    public async Task<IEnumerable<Spreadsheet>> Handle(GetAllSpreadsheetsQuery query)
    {
        return await spreadsheetRepository.ListAsync();
    }

    public async Task<Spreadsheet?> Handle(GetSpreadsheetByIdQuery query)
    {
        return await spreadsheetRepository.FindByIdAsync(query.Id);
    }

    public async Task<Spreadsheet?> Handle(GetSpreadsheetByNameQuery query)
    {
        return await spreadsheetRepository.FindByNameAsync(query.Name);
    }
}