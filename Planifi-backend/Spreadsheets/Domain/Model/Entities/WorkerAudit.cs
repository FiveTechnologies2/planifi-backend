using System.ComponentModel.DataAnnotations.Schema;

namespace Planifi_backend.Spreadsheets.Domain.Model.Entities;

public partial class Worker
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}