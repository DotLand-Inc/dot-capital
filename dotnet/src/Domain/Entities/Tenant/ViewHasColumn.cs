using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("VIEW_HAS_COLUMNS")]
public class ViewHasColumn : BaseEntity
{
    [Column("VIEW_ID")]
    public int ViewId { get; set; }

    [Column("FIELD_KEY")]
    public string? FieldKey { get; set; }

    [Column("INDEX")]
    public int Index { get; set; }
}
