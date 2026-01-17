using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("INVENTORY_ADJUSTMENTS")]
public class InventoryAdjustment : BaseEntity
{
    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("TYPE")]
    public string? Type { get; set; }

    [Column("ADJUSTMENT_ACCOUNT_ID")]
    public int AdjustmentAccountId { get; set; }

    [Column("REASON")]
    public string? Reason { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("PUBLISHED_AT")]
    public DateTime PublishedAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }
}
