using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("TAX_RATE_TRANSACTIONS")]
public class TaxRateTransaction : BaseEntity
{
    [Column("TAX_RATE_ID")]
    public int TaxRateId { get; set; }

    [Column("REFERENCE_TYPE")]
    public string? ReferenceType { get; set; }

    [Column("REFERENCE_ID")]
    public int ReferenceId { get; set; }

    [Column("RATE")]
    public decimal Rate { get; set; }

    [Column("TAX_ACCOUNT_ID")]
    public int TaxAccountId { get; set; }
}
