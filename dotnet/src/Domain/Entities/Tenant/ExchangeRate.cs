using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("EXCHANGE_RATES")]
public class ExchangeRate : BaseEntity
{
    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("EXCHANGE_RATE")]
    public decimal ExchangeRateProperty { get; set; }

    [Column("DATE")]
    public DateTime Date { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
