using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("SALES_ESTIMATES")]
public class SalesEstimate : BaseEntity
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

    [Column("CUSTOMER_ID")]
    public int CustomerId { get; set; }

    [Column("ESTIMATE_DATE")]
    public DateTime EstimateDate { get; set; }

    [Column("EXPIRATION_DATE")]
    public DateTime ExpirationDate { get; set; }

    [Column("REFERENCE")]
    public string? Reference { get; set; }

    [Column("ESTIMATE_NUMBER")]
    public string? EstimateNumber { get; set; }

    [Column("NOTE")]
    public string? Note { get; set; }

    [Column("TERMS_CONDITIONS")]
    public string? TermsConditions { get; set; }

    [Column("SEND_TO_EMAIL")]
    public string? SendToEmail { get; set; }

    [Column("DELIVERED_AT")]
    public DateTime DeliveredAt { get; set; }

    [Column("APPROVED_AT")]
    public DateTime ApprovedAt { get; set; }

    [Column("REJECTED_AT")]
    public DateTime RejectedAt { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CONVERTED_TO_INVOICE_ID")]
    public int ConvertedToInvoiceId { get; set; }

    [Column("CONVERTED_TO_INVOICE_AT")]
    public DateTime ConvertedToInvoiceAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("PDF_TEMPLATE_ID")]
    public int PdfTemplateId { get; set; }
}
