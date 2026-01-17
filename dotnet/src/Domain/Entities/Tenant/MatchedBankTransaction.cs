using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("MATCHED_BANK_TRANSACTIONS")]
public class MatchedBankTransaction : BaseEntity
{
    [Column("UNCATEGORIZED_TRANSACTION_ID")]
    public int UncategorizedTransactionId { get; set; }

    [Column("REFERENCE_TYPE")]
    public string? ReferenceType { get; set; }

    [Column("REFERENCE_ID")]
    public int ReferenceId { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
