using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("ROLE_PERMISSIONS")]
public class RolePermission : BaseEntity
{
    [Column("ROLE_ID")]
    public int RoleId { get; set; }

    [Column("SUBJECT")]
    public string? Subject { get; set; }

    [Column("ABILITY")]
    public string? Ability { get; set; }

    [Column("VALUE")]
    public bool Value { get; set; }
}
