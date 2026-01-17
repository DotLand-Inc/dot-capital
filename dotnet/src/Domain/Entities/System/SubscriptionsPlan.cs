using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("SUBSCRIPTIONS_PLANS")]
public class SubscriptionsPlan : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("PRICE")]
    public decimal Price { get; set; }

    [Column("CURRENCY")]
    public string? Currency { get; set; }

    [Column("TRIAL_PERIOD")]
    public int TrialPeriod { get; set; }

    [Column("TRIAL_INTERVAL")]
    public string? TrialInterval { get; set; }

    [Column("INVOICE_PERIOD")]
    public int InvoicePeriod { get; set; }

    [Column("INVOICE_INTERVAL")]
    public string? InvoiceInterval { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
