using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("CASHFLOW_TRANSACTIONS")]
public class CashflowTransaction : BaseEntity
{
    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("TRANSACTION_TYPE")]
    public string? TransactionType { get; set; }

    [Column("TRANSACTION_NUMBER")]
    public string? TransactionNumber { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("PUBLISHED_AT")]
    public DateTime PublishedAt { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("CASHFLOW_ACCOUNT_ID")]
    public int CashflowAccountId { get; set; }

    [Column("CREDIT_ACCOUNT_ID")]
    public int CreditAccountId { get; set; }

    [Column("PLAID_TRANSACTION_ID")]
    public string? PlaidTransactionId { get; set; }

    [Column("UNCATEGORIZED_TRANSACTION_ID")]
    public int UncategorizedTransactionId { get; set; }
}
