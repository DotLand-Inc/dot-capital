using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("ITEMS_ENTRIES")]
public class ItemsEntrie : BaseEntity
{
    [Column("REFERENCE_TYPE")]
    public string? ReferenceType { get; set; }

    [Column("REFERENCE_ID")]
    public string? ReferenceId { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }

    [Column("ITEM_ID")]
    public int ItemId { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("DISCOUNT")]
    public int Discount { get; set; }

    [Column("DISCOUNT_TYPE")]
    public string? DiscountType { get; set; }

    [Column("QUANTITY")]
    public decimal Quantity { get; set; }

    [Column("RATE")]
    public decimal Rate { get; set; }

    [Column("SELL_ACCOUNT_ID")]
    public int SellAccountId { get; set; }

    [Column("COST_ACCOUNT_ID")]
    public int CostAccountId { get; set; }

    [Column("LANDED_COST")]
    public bool LandedCost { get; set; }

    [Column("ALLOCATED_COST_AMOUNT")]
    public decimal AllocatedCostAmount { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    [Column("PROJECT_REF_ID")]
    public int ProjectRefId { get; set; }

    [Column("PROJECT_REF_TYPE")]
    public string? ProjectRefType { get; set; }

    [Column("PROJECT_REF_INVOICED_AMOUNT")]
    public decimal ProjectRefInvoicedAmount { get; set; }

    [Column("IS_INCLUSIVE_TAX")]
    public bool IsInclusiveTax { get; set; }

    [Column("TAX_RATE_ID")]
    public int TaxRateId { get; set; }

    [Column("TAX_RATE")]
    public decimal TaxRate { get; set; }
}
