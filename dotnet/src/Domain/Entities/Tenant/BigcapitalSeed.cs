using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BIGCAPITAL_SEEDS")]
public class BigcapitalSeed : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("BATCH")]
    public int Batch { get; set; }

    [Column("MIGRATION_TIME")]
    public DateTime MigrationTime { get; set; }
}
