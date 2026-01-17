using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("ROLES")]
public class Role : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("SLUG")]
    public string? Slug { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("PREDEFINED")]
    public bool Predefined { get; set; }
}
