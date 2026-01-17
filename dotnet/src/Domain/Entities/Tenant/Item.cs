using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("ITEMS")]
public class Item : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("TYPE")]
    public string? Type { get; set; }

    [Column("CODE")]
    public string? Code { get; set; }

    [Column("SELLABLE")]
    public bool Sellable { get; set; }

    [Column("PURCHASABLE")]
    public bool Purchasable { get; set; }

    [Column("SELL_PRICE")]
    public decimal SellPrice { get; set; }

    [Column("COST_PRICE")]
    public decimal CostPrice { get; set; }

    [Column("PICTURE_URI")]
    public string? PictureUri { get; set; }

    [Column("COST_ACCOUNT_ID")]
    public int CostAccountId { get; set; }

    [Column("SELL_ACCOUNT_ID")]
    public int SellAccountId { get; set; }

    [Column("INVENTORY_ACCOUNT_ID")]
    public int InventoryAccountId { get; set; }

    [Column("SELL_DESCRIPTION")]
    public string? SellDescription { get; set; }

    [Column("PURCHASE_DESCRIPTION")]
    public string? PurchaseDescription { get; set; }

    [Column("QUANTITY_ON_HAND")]
    public decimal QuantityOnHand { get; set; }

    [Column("LANDED_COST")]
    public bool LandedCost { get; set; }

    [Column("NOTE")]
    public string? Note { get; set; }

    [Column("ACTIVE")]
    public bool Active { get; set; }

    [Column("CATEGORY_ID")]
    public int CategoryId { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("SELL_TAX_RATE_ID")]
    public int SellTaxRateId { get; set; }

    [Column("PURCHASE_TAX_RATE_ID")]
    public int PurchaseTaxRateId { get; set; }
}
