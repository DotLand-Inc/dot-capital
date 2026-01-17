using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("INVENTORY_TRANSACTION_META")]
public class InventoryTransactionMeta : BaseEntity
{
    [Column("TRANSACTION_NUMBER")]
    public string? TransactionNumber { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("INVENTORY_TRANSACTION_ID")]
    public int InventoryTransactionId { get; set; }
}
