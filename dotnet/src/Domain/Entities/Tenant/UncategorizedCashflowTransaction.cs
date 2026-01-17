using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("UNCATEGORIZED_CASHFLOW_TRANSACTIONS")]
public class UncategorizedCashflowTransaction : BaseEntity
{
    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("PAYEE")]
    public string? Payee { get; set; }

    [Column("ACCOUNT_ID")]
    public int AccountId { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("CATEGORIZE_REF_TYPE")]
    public string? CategorizeRefType { get; set; }

    [Column("CATEGORIZE_REF_ID")]
    public int CategorizeRefId { get; set; }

    [Column("CATEGORIZED")]
    public bool Categorized { get; set; }

    [Column("PLAID_TRANSACTION_ID")]
    public string? PlaidTransactionId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("RECOGNIZED_TRANSACTION_ID")]
    public int RecognizedTransactionId { get; set; }

    [Column("EXCLUDED_AT")]
    public DateTime ExcludedAt { get; set; }

    [Column("BATCH")]
    public string? Batch { get; set; }

    [Column("PENDING")]
    public bool Pending { get; set; }

    [Column("PENDING_PLAID_TRANSACTION_ID")]
    public string? PendingPlaidTransactionId { get; set; }
}
