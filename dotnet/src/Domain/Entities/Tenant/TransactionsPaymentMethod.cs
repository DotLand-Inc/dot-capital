using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("TRANSACTIONS_PAYMENT_METHODS")]
public class TransactionsPaymentMethod : BaseEntity
{
    [Column("REFERENCE_ID")]
    public int ReferenceId { get; set; }

    [Column("REFERENCE_TYPE")]
    public string? ReferenceType { get; set; }

    [Column("PAYMENT_INTEGRATION_ID")]
    public int PaymentIntegrationId { get; set; }

    [Column("ENABLE")]
    public bool Enable { get; set; }

    [Column("OPTIONS")]
    public string? Options { get; set; }
}
