using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("EXPENSE_TRANSACTION_CATEGORIES")]
public class ExpenseTransactionCategorie : BaseEntity
{
    [Column("EXPENSE_ACCOUNT_ID")]
    public int ExpenseAccountId { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("ALLOCATED_COST_AMOUNT")]
    public decimal AllocatedCostAmount { get; set; }

    [Column("LANDED_COST")]
    public bool LandedCost { get; set; }

    [Column("EXPENSE_ID")]
    public int ExpenseId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }
}
