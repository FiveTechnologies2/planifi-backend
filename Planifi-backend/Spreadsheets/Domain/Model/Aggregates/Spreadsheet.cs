﻿using Planifi_backend.Spreadsheets.Domain.Model.Commands;
using Planifi_backend.Spreadsheets.Domain.Model.ValueObjects;
using Planifi_backend.Workers.Domain.Model.Aggregates;

namespace Planifi_backend.Spreadsheets.Domain.Model.Aggregates;

public partial class Spreadsheet
{
    public int Id { get; }
    
    public string SpreadsheetName { get; private set; }
    
    public string SpreadsheetDescription { get; private set; }
    
    public CompanyId CompanyId { get; set; }
    
    public List<Worker> Workers { get; set; }

    public Spreadsheet(string name, string description, CompanyId companyId)
    {
        SpreadsheetName = name;
        SpreadsheetDescription = description;
        CompanyId = companyId;
        Workers = new List<Worker>();
    }

    public Spreadsheet(CreateSpreadsheetCommand command)
    {
        SpreadsheetName = command.Name;
        SpreadsheetDescription = command.Description;
        CompanyId = new CompanyId(command.CompanyId);
        Workers = new List<Worker>();
    }
}