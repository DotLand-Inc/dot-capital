using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("ITEMS_WAREHOUSES_QUANTITY")]
public class ItemsWarehousesQuantity : BaseEntity
{
    [Column("ITEM_ID")]
    public int ItemId { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }

    [Column("QUANTITY_ON_HAND")]
    public int QuantityOnHand { get; set; }
}
