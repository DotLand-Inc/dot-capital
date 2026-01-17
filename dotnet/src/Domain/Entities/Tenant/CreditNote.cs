using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("CREDIT_NOTES")]
public class CreditNote : BaseEntity
{
    [Column("CUSTOMER_ID")]
    public int CustomerId { get; set; }

    [Column("CREDIT_NOTE_DATE")]
    public DateTime CreditNoteDate { get; set; }

    [Column("CREDIT_NOTE_NUMBER")]
    public string? CreditNoteNumber { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("REFUNDED_AMOUNT")]
    public decimal RefundedAmount { get; set; }

    [Column("INVOICES_AMOUNT")]
    public decimal InvoicesAmount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("DISCOUNT")]
    public decimal Discount { get; set; }

    [Column("DISCOUNT_TYPE")]
    public string? DiscountType { get; set; }

    [Column("ADJUSTMENT")]
    public decimal Adjustment { get; set; }

    [Column("NOTE")]
    public string? Note { get; set; }

    [Column("TERMS_CONDITIONS")]
    public string? TermsConditions { get; set; }

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

    [Column("PDF_TEMPLATE_ID")]
    public int PdfTemplateId { get; set; }
}
