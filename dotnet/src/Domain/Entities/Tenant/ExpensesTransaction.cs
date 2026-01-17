using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("EXPENSES_TRANSACTIONS")]
public class ExpensesTransaction : BaseEntity
{
    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("PAYMENT_ACCOUNT_ID")]
    public int PaymentAccountId { get; set; }

    [Column("PAYEE_ID")]
    public int PayeeId { get; set; }

    [Column("REFERENCE_NO")]
    public string? ReferenceNo { get; set; }

    [Column("TOTAL_AMOUNT")]
    public decimal TotalAmount { get; set; }

    [Column("LANDED_COST_AMOUNT")]
    public decimal LandedCostAmount { get; set; }

    [Column("ALLOCATED_COST_AMOUNT")]
    public decimal AllocatedCostAmount { get; set; }

    [Column("PUBLISHED_AT")]
    public DateTime PublishedAt { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("PAYMENT_DATE")]
    public DateTime PaymentDate { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    [Column("INVOICED_AMOUNT")]
    public decimal InvoicedAmount { get; set; }
}
