using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("TAX_RATES")]
public class TaxRate : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("CODE")]
    public string? Code { get; set; }

    [Column("RATE")]
    public decimal Rate { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("IS_NON_RECOVERABLE")]
    public bool IsNonRecoverable { get; set; }

    [Column("IS_COMPOUND")]
    public bool IsCompound { get; set; }

    [Column("ACTIVE")]
    public bool Active { get; set; }

    [Column("DELETED_AT")]
    public DateTime DeletedAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
