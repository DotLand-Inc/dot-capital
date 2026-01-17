using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("WAREHOUSES_TRANSFERS")]
public class WarehousesTransfer : BaseEntity
{
    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("TO_WAREHOUSE_ID")]
    public int ToWarehouseId { get; set; }

    [Column("FROM_WAREHOUSE_ID")]
    public int FromWarehouseId { get; set; }

    [Column("TRANSACTION_NUMBER")]
    public string? TransactionNumber { get; set; }

    [Column("TRANSFER_INITIATED_AT")]
    public DateTime TransferInitiatedAt { get; set; }

    [Column("TRANSFER_DELIVERED_AT")]
    public DateTime TransferDeliveredAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
