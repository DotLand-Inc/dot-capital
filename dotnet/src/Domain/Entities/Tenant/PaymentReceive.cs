using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("PAYMENT_RECEIVES")]
public class PaymentReceive : BaseEntity
{
    [Column("CUSTOMER_ID")]
    public int CustomerId { get; set; }

    [Column("PAYMENT_DATE")]
    public DateTime PaymentDate { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("DEPOSIT_ACCOUNT_ID")]
    public int DepositAccountId { get; set; }

    [Column("PAYMENT_RECEIVE_NO")]
    public string? PaymentReceiveNo { get; set; }

    [Column("STATEMENT")]
    public string? Statement { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("STRIPE_PINTENT_ID")]
    public string? StripePintentId { get; set; }

    [Column("PDF_TEMPLATE_ID")]
    public int PdfTemplateId { get; set; }
}
