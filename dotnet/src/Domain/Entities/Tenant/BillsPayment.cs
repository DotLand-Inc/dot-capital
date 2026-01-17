using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BILLS_PAYMENTS")]
public class BillsPayment : BaseEntity
{
    [Column("VENDOR_ID")]
    public int VendorId { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("PAYMENT_ACCOUNT_ID")]
    public int PaymentAccountId { get; set; }

    [Column("PAYMENT_NUMBER")]
    public string? PaymentNumber { get; set; }

    [Column("PAYMENT_DATE")]
    public DateTime PaymentDate { get; set; }

    [Column("PAYMENT_METHOD")]
    public string? PaymentMethod { get; set; }

    [Column("REFERENCE")]
    public string? Reference { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("STATEMENT")]
    public string? Statement { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }
}
