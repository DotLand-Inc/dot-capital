using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("CREDIT_NOTE_APPLIED_INVOICE")]
public class CreditNoteAppliedInvoice : BaseEntity
{
    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CREDIT_NOTE_ID")]
    public int CreditNoteId { get; set; }

    [Column("INVOICE_ID")]
    public int InvoiceId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
