using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("RECOGNIZED_BANK_TRANSACTIONS")]
public class RecognizedBankTransaction : BaseEntity
{
    [Column("UNCATEGORIZED_TRANSACTION_ID")]
    public int UncategorizedTransactionId { get; set; }

    [Column("BANK_RULE_ID")]
    public int BankRuleId { get; set; }

    [Column("ASSIGNED_CATEGORY")]
    public string? AssignedCategory { get; set; }

    [Column("ASSIGNED_ACCOUNT_ID")]
    public int AssignedAccountId { get; set; }

    [Column("ASSIGNED_PAYEE")]
    public string? AssignedPayee { get; set; }

    [Column("ASSIGNED_MEMO")]
    public string? AssignedMemo { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
