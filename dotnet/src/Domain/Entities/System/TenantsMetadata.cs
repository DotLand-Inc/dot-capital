using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("TENANTS_METADATA")]
public class TenantsMetadata : BaseEntity
{
    [Column("TENANT_ID")]
    public int TenantId { get; set; }

    [Column("NAME")]
    public string? Name { get; set; }

    [Column("INDUSTRY")]
    public string? Industry { get; set; }

    [Column("LOCATION")]
    public string? Location { get; set; }

    [Column("BASE_CURRENCY")]
    public string? BaseCurrency { get; set; }

    [Column("LANGUAGE")]
    public string? Language { get; set; }

    [Column("TIMEZONE")]
    public string? Timezone { get; set; }

    [Column("DATE_FORMAT")]
    public string? DateFormat { get; set; }

    [Column("FISCAL_YEAR")]
    public string? FiscalYear { get; set; }

    [Column("TAX_NUMBER")]
    public string? TaxNumber { get; set; }

    [Column("PRIMARY_COLOR")]
    public string? PrimaryColor { get; set; }

    [Column("LOGO_KEY")]
    public string? LogoKey { get; set; }

    [Column("ADDRESS")]
    public string? Address { get; set; }
}
