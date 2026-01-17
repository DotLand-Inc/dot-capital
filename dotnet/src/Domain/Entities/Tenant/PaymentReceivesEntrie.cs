using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("PAYMENT_RECEIVES_ENTRIES")]
public class PaymentReceivesEntrie : BaseEntity
{
    [Column("PAYMENT_RECEIVE_ID")]
    public int PaymentReceiveId { get; set; }

    [Column("INVOICE_ID")]
    public int InvoiceId { get; set; }

    [Column("PAYMENT_AMOUNT")]
    public decimal PaymentAmount { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }
}
