using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("VIEWS")]
public class View : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("SLUG")]
    public string? Slug { get; set; }

    [Column("PREDEFINED")]
    public bool Predefined { get; set; }

    [Column("RESOURCE_MODEL")]
    public string? ResourceModel { get; set; }

    [Column("FAVOURITE")]
    public bool Favourite { get; set; }

    [Column("ROLES_LOGIC_EXPRESSION")]
    public string? RolesLogicExpression { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
