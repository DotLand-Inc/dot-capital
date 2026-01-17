using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("IMPORTS")]
public class Import : BaseEntity
{
    [Column("FILENAME")]
    public string? Filename { get; set; }

    [Column("IMPORT_ID")]
    public string? ImportId { get; set; }

    [Column("RESOURCE")]
    public string? Resource { get; set; }

    [Column("COLUMNS")]
    public string? Columns { get; set; }

    [Column("MAPPING")]
    public string? Mapping { get; set; }

    [Column("PARAMS")]
    public string? Params { get; set; }

    [Column("TENANT_ID")]
    public long TenantId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
