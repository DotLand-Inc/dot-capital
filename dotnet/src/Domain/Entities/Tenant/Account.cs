using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("ACCOUNTS")]
public class Account : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("SLUG")]
    public string? Slug { get; set; }

    [Column("ACCOUNT_TYPE")]
    public string? AccountType { get; set; }

    [Column("PARENT_ACCOUNT_ID")]
    public int ParentAccountId { get; set; }

    [Column("CODE")]
    public string? Code { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("ACTIVE")]
    public bool Active { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }

    [Column("PREDEFINED")]
    public bool Predefined { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("SEEDED_AT")]
    public DateTime SeededAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("PLAID_ACCOUNT_ID")]
    public string? PlaidAccountId { get; set; }

    [Column("ACCOUNT_MASK")]
    public string? AccountMask { get; set; }

    [Column("BANK_BALANCE")]
    public decimal BankBalance { get; set; }

    [Column("UNCATEGORIZED_TRANSACTIONS")]
    public int UncategorizedTransactions { get; set; }

    [Column("IS_SYSTEM_ACCOUNT")]
    public bool IsSystemAccount { get; set; }

    [Column("IS_FEEDS_ACTIVE")]
    public bool IsFeedsActive { get; set; }

    [Column("IS_SYNCING_OWNER")]
    public bool IsSyncingOwner { get; set; }

    [Column("LAST_FEEDS_UPDATED_AT")]
    public DateTime LastFeedsUpdatedAt { get; set; }

    [Column("PLAID_ITEM_ID")]
    public string? PlaidItemId { get; set; }
}
