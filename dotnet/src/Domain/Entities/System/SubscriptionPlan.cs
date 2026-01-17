using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("SUBSCRIPTION_PLANS")]
public class SubscriptionPlan : BaseEntity
{
    [Column("SLUG")]
    public string? Slug { get; set; }

    [Column("NAME")]
    public string? Name { get; set; }

    [Column("DESC")]
    public string? Desc { get; set; }

    [Column("ACTIVE")]
    public bool Active { get; set; }

    [Column("PRICE")]
    public decimal Price { get; set; }

    [Column("CURRENCY")]
    public string? Currency { get; set; }

    [Column("TRIAL_PERIOD")]
    public decimal TrialPeriod { get; set; }

    [Column("TRIAL_INTERVAL")]
    public string? TrialInterval { get; set; }

    [Column("INVOICE_PERIOD")]
    public decimal InvoicePeriod { get; set; }

    [Column("INVOICE_INTERVAL")]
    public string? InvoiceInterval { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("LEMON_VARIANT_ID")]
    public string? LemonVariantId { get; set; }
}
