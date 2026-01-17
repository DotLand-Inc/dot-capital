using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BILL_LOCATED_COSTS")]
public class BillLocatedCost : BaseEntity
{
    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("FROM_TRANSACTION_ID")]
    public int FromTransactionId { get; set; }

    [Column("FROM_TRANSACTION_TYPE")]
    public string? FromTransactionType { get; set; }

    [Column("FROM_TRANSACTION_ENTRY_ID")]
    public int FromTransactionEntryId { get; set; }

    [Column("ALLOCATION_METHOD")]
    public string? AllocationMethod { get; set; }

    [Column("COST_ACCOUNT_ID")]
    public int CostAccountId { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("BILL_ID")]
    public int BillId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
