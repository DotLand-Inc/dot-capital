using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("SALES_RECEIPTS")]
public class SalesReceipt : BaseEntity
{
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

    [Column("DEPOSIT_ACCOUNT_ID")]
    public int DepositAccountId { get; set; }

    [Column("CUSTOMER_ID")]
    public int CustomerId { get; set; }

    [Column("RECEIPT_DATE")]
    public DateTime ReceiptDate { get; set; }

    [Column("RECEIPT_NUMBER")]
    public string? ReceiptNumber { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("SEND_TO_EMAIL")]
    public string? SendToEmail { get; set; }

    [Column("RECEIPT_MESSAGE")]
    public string? ReceiptMessage { get; set; }

    [Column("STATEMENT")]
    public string? Statement { get; set; }

    [Column("CLOSED_AT")]
    public DateTime ClosedAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("PDF_TEMPLATE_ID")]
    public int PdfTemplateId { get; set; }
}
