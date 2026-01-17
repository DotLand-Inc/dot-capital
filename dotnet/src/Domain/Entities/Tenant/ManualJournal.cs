using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("MANUAL_JOURNALS")]
public class ManualJournal : BaseEntity
{
    [Column("JOURNAL_NUMBER")]
    public string? JournalNumber { get; set; }

    [Column("REFERENCE")]
    public string? Reference { get; set; }

    [Column("JOURNAL_TYPE")]
    public string? JournalType { get; set; }

    [Column("AMOUNT")]
    public decimal Amount { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRate { get; set; }

    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("PUBLISHED_AT")]
    public DateTime PublishedAt { get; set; }

    [Column("ATTACHMENT_FILE")]
    public string? AttachmentFile { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }
}
