using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("WAREHOUSES_TRANSFERS_ENTRIES")]
public class WarehousesTransfersEntrie : BaseEntity
{
    [Column("INDEX")]
    public int Index { get; set; }

    [Column("WAREHOUSE_TRANSFER_ID")]
    public int WarehouseTransferId { get; set; }

    [Column("ITEM_ID")]
    public int ItemId { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("QUANTITY")]
    public int Quantity { get; set; }

    [Column("COST")]
    public decimal Cost { get; set; }
}
