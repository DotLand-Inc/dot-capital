using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BANK_RULES")]
public class BankRule : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("ORDER")]
    public int Order { get; set; }

    [Column("APPLY_IF_ACCOUNT_ID")]
    public int ApplyIfAccountId { get; set; }

    [Column("APPLY_IF_TRANSACTION_TYPE")]
    public string? ApplyIfTransactionType { get; set; }

    [Column("ASSIGN_CATEGORY")]
    public string? AssignCategory { get; set; }

    [Column("ASSIGN_ACCOUNT_ID")]
    public int AssignAccountId { get; set; }

    [Column("ASSIGN_PAYEE")]
    public string? AssignPayee { get; set; }

    [Column("ASSIGN_MEMO")]
    public string? AssignMemo { get; set; }

    [Column("CONDITIONS_TYPE")]
    public string? ConditionsType { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
