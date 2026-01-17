using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("SETTINGS")]
public class Setting : BaseEntity
{
    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("GROUP")]
    public string? Group { get; set; }

    [Column("TYPE")]
    public string? Type { get; set; }

    [Column("KEY")]
    public string? Key { get; set; }

    [Column("VALUE")]
    public string? Value { get; set; }
}
