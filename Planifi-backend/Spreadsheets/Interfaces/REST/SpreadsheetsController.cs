using Microsoft.AspNetCore.Mvc;
using Planifi_backend.Spreadsheets.Domain.Model.Queries;
using Planifi_backend.Spreadsheets.Domain.Services;
using Planifi_backend.Spreadsheets.Interfaces.REST.Resources;
using Planifi_backend.Spreadsheets.Interfaces.REST.Transform;

namespace Planifi_backend.Spreadsheets.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class SpreadsheetsController(
    ISpreadsheetCommandService spreadsheetCommandService,
    ISpreadsheetQueryService spreadsheetQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSpreadsheet([FromBody] CreateSpreadsheetResource createSpreadsheetResource)
    {
        var createSpreadsheetCommand =
            CreateSpreadsheetCommandFromResourceAssembler.ToCommandFromResource(createSpreadsheetResource);
        var spreadsheet = await spreadsheetCommandService.Handle(createSpreadsheetCommand);
        if (spreadsheet is null) return BadRequest();
        return CreatedAtAction(nameof(GetSpreadsheetById), new { spreadsheetId = spreadsheet.Id }, spreadsheet);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSpreadsheets()
    {
        var getAllSpreadsheetsQuery = new GetAllSpreadsheetsQuery();
        var spreadsheets = await spreadsheetQueryService.Handle(getAllSpreadsheetsQuery);
        var resources = spreadsheets.Select(SpreadsheetResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(spreadsheets);
    }

    [HttpGet("{spreadsheetId}")]
    public async Task<IActionResult> GetSpreadsheetById([FromRoute] int spreadsheetId)
    {
        var spreadsheet = await spreadsheetQueryService.Handle(new GetSpreadsheetByIdQuery(spreadsheetId));
        if (spreadsheet == null) return NotFound();
        var resource = SpreadsheetResourceFromEntityAssembler.ToResourceFromEntity(spreadsheet);
        return Ok(resource);
    }
}