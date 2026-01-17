using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("PLAID_ITEMS")]
public class PlaidItem : BaseEntity
{
    [Column("TENANT_ID")]
    public long TenantId { get; set; }

    [Column("PLAID_ITEM_ID")]
    public string? PlaidItemId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
