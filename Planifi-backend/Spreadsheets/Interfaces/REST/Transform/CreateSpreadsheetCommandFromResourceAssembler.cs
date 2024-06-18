using Planifi_backend.Spreadsheets.Domain.Model.Commands;
using Planifi_backend.Spreadsheets.Interfaces.REST.Resources;

namespace Planifi_backend.Spreadsheets.Interfaces.REST.Transform;

public class CreateSpreadsheetCommandFromResourceAssembler
{
    public static CreateSpreadsheetCommand ToCommandFromResource(CreateSpreadsheetResource resource)
    {
        return new CreateSpreadsheetCommand(resource.Name, resource.Description, resource.CompanyId);
    }
}