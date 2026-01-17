using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("PAYMENT_LINKS")]
public class PaymentLink : BaseEntity
{
    [Column("TENANT_ID")]
    public int TenantId { get; set; }

    [Column("RESOURCE_ID")]
    public int ResourceId { get; set; }

    [Column("RESOURCE_TYPE")]
    public string? ResourceType { get; set; }

    [Column("LINK_ID")]
    public string? LinkId { get; set; }

    [Column("PUBLICITY")]
    public string? Publicity { get; set; }

    [Column("EXPIRY_AT")]
    public DateTime ExpiryAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
