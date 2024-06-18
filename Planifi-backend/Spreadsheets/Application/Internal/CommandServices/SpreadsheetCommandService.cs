using Planifi_backend.Shared.Domain.Repositories;
using Planifi_backend.Spreadsheets.Domain.Model.Aggregates;
using Planifi_backend.Spreadsheets.Domain.Model.Commands;
using Planifi_backend.Spreadsheets.Domain.Repositories;
using Planifi_backend.Spreadsheets.Domain.Services;

namespace Planifi_backend.Spreadsheets.Application.Internal.CommandServices;

public class SpreadsheetCommandService(ISpreadsheetRepository spreadsheetRepository, IUnitOfWork unitOfWork) : ISpreadsheetCommandService
{
    public async Task<Spreadsheet?> Handle(CreateSpreadsheetCommand command)
    {
        var spreadsheet = new Spreadsheet(command);
        try
        {
            await spreadsheetRepository.AddAsync(spreadsheet);
            await unitOfWork.CompleteAsync();
            return spreadsheet;
        }
        catch
        {
            return null;
        }
    }
}