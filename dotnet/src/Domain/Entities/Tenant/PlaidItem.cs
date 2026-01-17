using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("PLAID_ITEMS")]
public class PlaidItem : BaseEntity
{
    [Column("TENANT_ID")]
    public int TenantId { get; set; }

    [Column("PLAID_ITEM_ID")]
    public string? PlaidItemId { get; set; }

    [Column("PLAID_INSTITUTION_ID")]
    public string? PlaidInstitutionId { get; set; }

    [Column("PLAID_ACCESS_TOKEN")]
    public string? PlaidAccessToken { get; set; }

    [Column("LAST_CURSOR")]
    public string? LastCursor { get; set; }

    [Column("STATUS")]
    public string? Status { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("PAUSED_AT")]
    public DateTime PausedAt { get; set; }
}
