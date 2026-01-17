using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("VENDOR_CREDIT_APPLIED_BILL")]
public class VendorCreditAppliedBill : BaseEntity
{
    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("VENDOR_CREDIT_ID")]
    public int VendorCreditId { get; set; }

    [Column("BILL_ID")]
    public int BillId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

}
