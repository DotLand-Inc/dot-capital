using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("STRIPE_ACCOUNTS")]
public class StripeAccount : BaseEntity
{
    [Column("STRIPE_ACCOUNT_ID")]
    public string? StripeAccountId { get; set; }

    [Column("TENANT_ID")]
    public string? TenantId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
