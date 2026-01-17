using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("PAYMENT_INTEGRATIONS")]
public class PaymentIntegration : BaseEntity
{
    [Column("SERVICE")]
    public string? Service { get; set; }

    [Column("NAME")]
    public string? Name { get; set; }

    [Column("SLUG")]
    public string? Slug { get; set; }

    [Column("PAYMENT_ENABLED")]
    public bool PaymentEnabled { get; set; }

    [Column("PAYOUT_ENABLED")]
    public bool PayoutEnabled { get; set; }

    [Column("ACCOUNT_ID")]
    public string? AccountId { get; set; }

    [Column("OPTIONS")]
    public string? Options { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
