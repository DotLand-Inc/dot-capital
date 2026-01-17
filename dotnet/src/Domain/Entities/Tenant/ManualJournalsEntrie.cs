using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("MANUAL_JOURNALS_ENTRIES")]
public class ManualJournalsEntrie : BaseEntity
{
    [Column("CREDIT")]
    public decimal Credit { get; set; }

    [Column("DEBIT")]
    public decimal Debit { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }

    [Column("ACCOUNT_ID")]
    public int AccountId { get; set; }

    [Column("CONTACT_ID")]
    public int ContactId { get; set; }

    [Column("NOTE")]
    public string? Note { get; set; }

    [Column("MANUAL_JOURNAL_ID")]
    public int ManualJournalId { get; set; }

    [Column("BRANCH_ID")]
    public int BranchId { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }
}
