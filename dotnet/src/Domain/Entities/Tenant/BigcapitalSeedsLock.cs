using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BIGCAPITAL_SEEDS_LOCK")]
public class BigcapitalSeedsLock : BaseEntity
{
    [Column("INDEX")]
    public int Index { get; set; }

    [Column("IS_LOCKED")]
    public int IsLocked { get; set; }
}
