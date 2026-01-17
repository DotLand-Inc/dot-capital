using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("ITEMS_CATEGORIES")]
public class ItemsCategorie : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("COST_ACCOUNT_ID")]
    public int CostAccountId { get; set; }

    [Column("SELL_ACCOUNT_ID")]
    public int SellAccountId { get; set; }

    [Column("INVENTORY_ACCOUNT_ID")]
    public int InventoryAccountId { get; set; }

    [Column("COST_METHOD")]
    public string? CostMethod { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
