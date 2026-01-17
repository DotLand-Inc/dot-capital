using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("ACCOUNTS_TRANSACTIONS")]
public class AccountsTransaction : BaseEntity
{
    [Column("CREDIT")]
    public decimal Credit { get; set; }

    [Column("DEBIT")]
    public decimal Debit { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("TRANSACTION_TYPE")]
    public string? TransactionType { get; set; }

    [Column("REFERENCE_TYPE")]
    public string? ReferenceType { get; set; }

    [Column("REFERENCE_ID")]
    public int ReferenceId { get; set; }

    [Column("ACCOUNT_ID")]
    public int AccountId { get; set; }

    [Column("CONTACT_TYPE")]
    public string? ContactType { get; set; }

    [Column("CONTACT_ID")]
    public int ContactId { get; set; }

    [Column("TRANSACTION_NUMBER")]
    public string? TransactionNumber { get; set; }

    [Column("REFERENCE_NUMBER")]
    public string? ReferenceNumber { get; set; }

    [Column("ITEM_ID")]
    public int ItemId { get; set; }

    [Column("ITEM_QUANTITY")]
    public int ItemQuantity { get; set; }

    [Column("NOTE")]
    public string? Note { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("INDEX_GROUP")]
    public int IndexGroup { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }

    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("COSTABLE")]
    public bool Costable { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    [Column("TAX_RATE_ID")]
    public int TaxRateId { get; set; }

    [Column("TAX_RATE")]
    public decimal TaxRate { get; set; }
}
