using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BRANCHES")]
public class Branche : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("CODE")]
    public string? Code { get; set; }

    [Column("ADDRESS")]
    public string? Address { get; set; }

    [Column("CITY")]
    public string? City { get; set; }

    [Column("COUNTRY")]
    public string? Country { get; set; }

    [Column("PHONE_NUMBER")]
    public string? PhoneNumber { get; set; }

    [Column("EMAIL")]
    public string? Email { get; set; }

    [Column("WEBSITE")]
    public string? Website { get; set; }

    [Column("PRIMARY")]
    public bool Primary { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
