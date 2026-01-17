using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BILLS_PAYMENTS_ENTRIES")]
public class BillsPaymentsEntrie : BaseEntity
{
    [Column("BILL_PAYMENT_ID")]
    public int BillPaymentId { get; set; }

    [Column("BILL_ID")]
    public int BillId { get; set; }

    [Column("PAYMENT_AMOUNT")]
    public decimal PaymentAmount { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }
}
