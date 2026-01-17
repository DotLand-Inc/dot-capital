using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("TENANTS")]
public class TenantEntity : BaseAuditableEntity
{
    [Column("ORGANIZATION_ID")]
    public string? OrganizationId { get; set; } = string.Empty;

    [Column("UNDER_MAINTENANCE_SINCE")]
    public DateTime UnderMaintenanceSince { get; set; }

    [Column("INITIALIZED_AT")]
    public DateTime InitializedAt { get; set; }

    [Column("SEEDED_AT")]
    public DateTime SeededAt { get; set; }

    [Column("BUILT_AT")]
    public DateTime BuiltAt { get; set; }

    [Column("BUILD_JOB_ID")]
    public string? BuildJobId { get; set; }

    [Column("DATABASE_BATCH")]
    public int DatabaseBatch { get; set; }

    [Column("UPGRADE_JOB_ID")]
    public string? UpgradeJobId { get; set; }
}
