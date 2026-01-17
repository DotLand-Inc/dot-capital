using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BILLS")]
public class Bill : BaseEntity
{
    [Column("VENDOR_ID")]
    public int VendorId { get; set; }

    [Column("BILL_NUMBER")]
    public string? BillNumber { get; set; }

    [Column("BILL_DATE")]
    public DateTime BillDate { get; set; }

    [Column("DUE_DATE")]
    public DateTime DueDate { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("STATUS")]
    public string? Status { get; set; }

    [Column("NOTE")]
    public string? Note { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("DISCOUNT")]
    public decimal Discount { get; set; }

    [Column("DISCOUNT_TYPE")]
    public string? DiscountType { get; set; }

    [Column("ADJUSTMENT")]
    public decimal Adjustment { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("PAYMENT_AMOUNT")]
    public decimal PaymentAmount { get; set; }

    [Column("LANDED_COST_AMOUNT")]
    public decimal LandedCostAmount { get; set; }

    [Column("ALLOCATED_COST_AMOUNT")]
    public decimal AllocatedCostAmount { get; set; }

    [Column("CREDITED_AMOUNT")]
    public decimal CreditedAmount { get; set; }

    [Column("INV_LOT_NUMBER")]
    public string? InvLotNumber { get; set; }

    [Column("OPENED_AT")]
    public DateTime OpenedAt { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    [Column("INVOICED_AMOUNT")]
    public decimal InvoicedAmount { get; set; }

    [Column("IS_INCLUSIVE_TAX")]
    public bool IsInclusiveTax { get; set; }

    [Column("TAX_AMOUNT_WITHHELD")]
    public decimal TaxAmountWithheld { get; set; }
}
