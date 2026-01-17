using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("MEDIA_LINKS")]
public class MediaLink : BaseEntity
{
    [Column("MODEL_NAME")]
    public string? ModelName { get; set; }

    [Column("MEDIA_ID")]
    public int MediaId { get; set; }

    [Column("MODEL_ID")]
    public int ModelId { get; set; }
}
