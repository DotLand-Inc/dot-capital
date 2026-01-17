using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("CURRENCIES")]
public class Currencie : BaseEntity
{
    [Column("CURRENCY_NAME")]
    public string? CurrencyName { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("CURRENCY_SIGN")]
    public string? CurrencySign { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
