using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("REFUND_VENDOR_CREDIT_TRANSACTIONS")]
public class RefundVendorCreditTransaction : BaseEntity
{
    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("VENDOR_CREDIT_ID")]
    public int VendorCreditId { get; set; }

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

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
