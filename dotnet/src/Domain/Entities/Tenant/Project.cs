using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("PROJECTS")]
public class Project : BaseEntity
{
    [Column("NAME")]
    public string? Name { get; set; }

    [Column("CONTACT_ID")]
    public int ContactId { get; set; }

    [Column("DEADLINE")]
    public DateTime Deadline { get; set; }

    [Column("COST_ESTIMATE")]
    public decimal CostEstimate { get; set; }

    [Column("STATUS")]
    public string? Status { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
