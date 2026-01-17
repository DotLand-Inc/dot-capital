using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("TASKS")]
public class TaskEntity : BaseEntity
{
    // Id inherited from BaseEntity

    [Column("NAME")]
    public string? Name { get; set; }

    [Column("CHARGE_TYPE")]
    public string? ChargeType { get; set; }

    [Column("RATE")]
    public decimal Rate { get; set; }

    [Column("ESTIMATE_HOURS")]
    public decimal EstimateHours { get; set; }

    [Column("ACTUAL_HOURS")]
    public decimal ActualHours { get; set; }

    [Column("INVOICED_HOURS")]
    public decimal InvoicedHours { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
