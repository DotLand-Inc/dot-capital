using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("ONECLICK_DEMOS")]
public class OneClickDemo : BaseEntity
{
    [Column("KEY")]
    public string? Key { get; set; }

    [Column("TENANT_ID")]
    public int TenantId { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
