using System.ComponentModel.DataAnnotations.Schema;

namespace Planifi_backend.Spreadsheets.Domain.Model.Aggregates;

public class SpreadsheetAudit
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}