using Microsoft.EntityFrameworkCore;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Planifi_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Planifi_backend.Spreadsheets.Domain.Model.Aggregates;
using Planifi_backend.Spreadsheets.Domain.Repositories;

namespace Planifi_backend.Spreadsheets.Infrastructure.Persistence.EFC.Repositories;

public class SpreadsheetRepository(AppDbContext context) : BaseRepository<Spreadsheet>(context), ISpreadsheetRepository
{
    public new async Task<Spreadsheet?> FindByIdAsync(int id) =>
        await Context.Set<Spreadsheet>().Include(s => s.SpreadsheetName)
            .Where(s => s.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Spreadsheet>> ListAsync()
    {
        return await Context.Set<Spreadsheet>()
            .Include(spreadsheet => spreadsheet.SpreadsheetName)
            .ToListAsync();
    }
    public new async Task<Spreadsheet?> FindByNameAsync(string name) =>
        await Context.Set<Spreadsheet>().Include(s => s.SpreadsheetName)
            .Where(s => s.SpreadsheetName == name).FirstOrDefaultAsync();
}