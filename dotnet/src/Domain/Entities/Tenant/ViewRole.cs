using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("VIEW_ROLES")]
public class ViewRole : BaseEntity
{
    [Column("INDEX")]
    public int Index { get; set; }

    [Column("FIELD_KEY")]
    public string? FieldKey { get; set; }

    [Column("COMPARATOR")]
    public string? Comparator { get; set; }

    [Column("VALUE")]
    public string? Value { get; set; }

    [Column("VIEW_ID")]
    public int ViewId { get; set; }
}
