using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("knex_migrations_lock")]
public class KnexMigrationsLock : BaseEntity
{
    [Column("index")]
    public int Index { get; set; }

    [Column("is_locked")]
    public int IsLocked { get; set; }
}
