using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("SALES_INVOICES")]
public class SalesInvoice : BaseEntity
{
    [Column("CUSTOMER_ID")]
    public int CustomerId { get; set; }

    [Column("INVOICE_DATE")]
    public DateTime InvoiceDate { get; set; }

    [Column("DUE_DATE")]
    public DateTime DueDate { get; set; }

    [Column("INVOICE_NO")]
    public string? InvoiceNo { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("INVOICE_MESSAGE")]
    public string? InvoiceMessage { get; set; }

    [Column("TERMS_CONDITIONS")]
    public string? TermsConditions { get; set; }

    [Column("BALANCE")]
    public decimal Balance { get; set; }

    [Column("PAYMENT_AMOUNT")]
    public decimal PaymentAmount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("CREDITED_AMOUNT")]
    public decimal CreditedAmount { get; set; }

    [Column("DISCOUNT")]
    public decimal Discount { get; set; }

    [Column("DISCOUNT_TYPE")]
    public string? DiscountType { get; set; }

    [Column("ADJUSTMENT")]
    public decimal Adjustment { get; set; }

    [Column("INV_LOT_NUMBER")]
    public string? InvLotNumber { get; set; }

    [Column("DELIVERED_AT")]
    public DateTime DeliveredAt { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("WRITTENOFF_AMOUNT")]
    public decimal WrittenoffAmount { get; set; }

    [Column("WRITTENOFF_AT")]
    public DateTime WrittenoffAt { get; set; }

    [Column("WAREHOUSE_ID")]
    public int WarehouseId { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("WRITTENOFF_EXPENSE_ACCOUNT_ID")]
    public int WrittenoffExpenseAccountId { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    [Column("IS_INCLUSIVE_TAX")]
    public bool IsInclusiveTax { get; set; }

    [Column("TAX_AMOUNT_WITHHELD")]
    public decimal TaxAmountWithheld { get; set; }

    [Column("PDF_TEMPLATE_ID")]
    public int PdfTemplateId { get; set; }
}
