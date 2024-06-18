using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Planifi_backend.DataEntry.Domain.Model.Entities;

public partial class Asset : IEntityWithCreatedUpdatedDate 
{
    [Column("CreateAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}