using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("DOCUMENT_LINKS")]
public class DocumentLink : BaseEntity
{
    [Column("MODEL_REF")]
    public string? ModelRef { get; set; }

    [Column("MODEL_ID")]
    public string? ModelId { get; set; }

    [Column("DOCUMENT_ID")]
    public int DocumentId { get; set; }

    [Column("EXPIRES_AT")]
    public DateTime ExpiresAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
