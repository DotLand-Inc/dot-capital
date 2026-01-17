using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("INVENTORY_TRANSACTIONS")]
public class InventoryTransaction : BaseEntity
{
    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("DIRECTION")]
    public string? Direction { get; set; }

    [Column("ITEM_ID")]
    public int ItemId { get; set; }

    [Column("QUANTITY")]
    public decimal Quantity { get; set; }

    [Column("RATE")]
    public decimal Rate { get; set; }

    [Column("TRANSACTION_TYPE")]
    public string? TransactionType { get; set; }

    [Column("TRANSACTION_ID")]
    public int TransactionId { get; set; }

    [Column("ENTRY_ID")]
    public int EntryId { get; set; }

    [Column("COST_ACCOUNT_ID")]
    public int CostAccountId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }
}
