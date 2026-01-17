using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("SUBSCRIPTION_PLAN_SUBSCRIPTIONS")]
public class SubscriptionPlanSubscription : BaseEntity
{
    [Column("SLUG")]
    public string? Slug { get; set; }

    [Column("PLAN_ID")]
    public int PlanId { get; set; }

    [Column("TENANT_ID")]
    public long TenantId { get; set; }

    [Column("STARTS_AT")]
    public DateTime StartsAt { get; set; }

    [Column("ENDS_AT")]
    public DateTime EndsAt { get; set; }

    [Column("CANCELED_AT")]
    public DateTime CanceledAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("LEMON_SUBSCRIPTION_ID")]
    public string? LemonSubscriptionId { get; set; }

    [Column("TRIAL_ENDS_AT")]
    public DateTime TrialEndsAt { get; set; }

    [Column("PAYMENT_STATUS")]
    public string? PaymentStatus { get; set; }
}
