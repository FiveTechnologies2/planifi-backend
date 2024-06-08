using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreateUpdateDate.Contracts;

namespace Planifi_backend.Workers.Domain.Model.Aggregates;

public partial class Worker : IEntityWithCreateUpdateDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdateAt")] public DateTimeOffset? UpdatedDate { get; set; }
}