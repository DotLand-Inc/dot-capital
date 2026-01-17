using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("VENDOR_CREDITS")]
public class VendorCredit : BaseEntity
{
    [Column("VENDOR_ID")]
    public int VendorId { get; set; }

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

    [Column("VENDOR_CREDIT_DATE")]
    public DateTime VendorCreditDate { get; set; }

    [Column("VENDOR_CREDIT_NUMBER")]
    public string? VendorCreditNumber { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("REFUNDED_AMOUNT")]
    public decimal RefundedAmount { get; set; }

    [Column("INVOICED_AMOUNT")]
    public decimal InvoicedAmount { get; set; }

    [Column("NOTE")]
    public string? Note { get; set; }

    [Column("OPENED_AT")]
    public DateTime OpenedAt { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }
}
