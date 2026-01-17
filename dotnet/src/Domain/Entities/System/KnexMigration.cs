using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("knex_migrations")]
public class KnexMigration : BaseEntity
{
    [Column("name")]
    public string? Name { get; set; }

    [Column("batch")]
    public int Batch { get; set; }

    [Column("migration_time")]
    public DateTime MigrationTime { get; set; }
}
