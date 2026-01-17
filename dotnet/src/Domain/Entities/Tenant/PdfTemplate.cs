using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("PDF_TEMPLATES")]
public class PdfTemplate : BaseEntity
{
    [Column("RESOURCE")]
    public string? Resource { get; set; }

    [Column("TEMPLATE_NAME")]
    public string? TemplateName { get; set; }

    [Column("ATTRIBUTES")]
    public string? Attributes { get; set; }

    [Column("PREDEFINED")]
    public bool Predefined { get; set; }

    [Column("DEFAULT")]
    public bool Default { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
