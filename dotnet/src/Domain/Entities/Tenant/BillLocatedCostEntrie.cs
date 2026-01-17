using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BILL_LOCATED_COST_ENTRIES")]
public class BillLocatedCostEntrie : BaseEntity
{
    [Column("COST")]
    public decimal Cost { get; set; }

    [Column("ENTRY_ID")]
    public int EntryId { get; set; }

    [Column("BILL_LOCATED_COST_ID")]
    public int BillLocatedCostId { get; set; }
}
