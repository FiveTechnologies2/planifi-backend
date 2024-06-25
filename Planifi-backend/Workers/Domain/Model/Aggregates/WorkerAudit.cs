

using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Planifi_backend.Workers.Domain.Model.Aggregates;

public partial class WorkerAudit : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
    
}