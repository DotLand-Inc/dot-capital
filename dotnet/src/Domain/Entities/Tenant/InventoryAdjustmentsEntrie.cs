using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("INVENTORY_ADJUSTMENTS_ENTRIES")]
public class InventoryAdjustmentsEntrie : BaseEntity
{
    [Column("ADJUSTMENT_ID")]
    public int AdjustmentId { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }

    [Column("ITEM_ID")]
    public int ItemId { get; set; }

    [Column("QUANTITY")]
    public int Quantity { get; set; }

    [Column("COST")]
    public decimal Cost { get; set; }

    [Column("VALUE")]
    public decimal Value { get; set; }
}
