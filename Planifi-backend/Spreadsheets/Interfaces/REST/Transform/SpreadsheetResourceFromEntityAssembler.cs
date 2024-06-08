using Planifi_backend.Spreadsheets.Domain.Model.Aggregates;
using Planifi_backend.Spreadsheets.Interfaces.REST.Resources;

namespace Planifi_backend.Spreadsheets.Interfaces.REST.Transform;

public class SpreadsheetResourceFromEntityAssembler
{
    public static SpreadsheetResource ToResourceFromEntity(Spreadsheet spreadsheet)
    {
        return new SpreadsheetResource(
            spreadsheet.Id,
            spreadsheet.SpreadsheetName,
            spreadsheet.SpreadsheetDescription,
            spreadsheet.CompanyId);
    }
}