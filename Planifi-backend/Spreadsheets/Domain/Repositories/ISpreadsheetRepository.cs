using Planifi_backend.Shared.Domain.Repositories;
using Planifi_backend.Spreadsheets.Domain.Model.Aggregates;

namespace Planifi_backend.Spreadsheets.Domain.Repositories;

public interface ISpreadsheetRepository : IBaseRepository<Spreadsheet>
{
    Task<Spreadsheet?> FindByNameAsync(string name);
}