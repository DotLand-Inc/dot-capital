using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("TIMES")]
public class Time : BaseEntity
{
    [Column("DURATION")]
    public int Duration { get; set; }

    [Column("DESCRIPTION")]
    public string? Description { get; set; }

    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("TASK_ID")]
    public int TaskId { get; set; }

    [Column("PROJECT_ID")]
    public int ProjectId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
