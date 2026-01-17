using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("DOCUMENTS")]
public class Document : BaseEntity
{
    [Column("KEY")]
    public string? Key { get; set; }

    [Column("MIME_TYPE")]
    public string? MimeType { get; set; }

    [Column("SIZE")]
    public int Size { get; set; }

    [Column("ORIGIN_NAME")]
    public string? OriginName { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
