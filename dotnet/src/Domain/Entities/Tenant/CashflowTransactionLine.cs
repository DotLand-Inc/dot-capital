using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("CASHFLOW_TRANSACTION_LINES")]
public class CashflowTransactionLine : BaseEntity
{
    [Column("CASHFLOW_TRANSACTION_ID")]
    public int CashflowTransactionId { get; set; }

    [Column("CASHFLOW_ACCOUNT_ID")]
    public int CashflowAccountId { get; set; }

    [Column("CREDIT_ACCOUNT_ID")]
    public int CreditAccountId { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
