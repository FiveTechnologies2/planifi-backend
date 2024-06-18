using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Planifi_backend.DataEntry.Domain.Model.Aggregates;

public partial class Worker : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdateAt")] public DateTimeOffset? UpdatedDate { get; set; }
}