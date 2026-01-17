using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("BANK_RULE_CONDITIONS")]
public class BankRuleCondition : BaseEntity
{
    [Column("RULE_ID")]
    public int RuleId { get; set; }

    [Column("FIELD")]
    public string? Field { get; set; }

    [Column("COMPARATOR")]
    public string? Comparator { get; set; }

    [Column("VALUE")]
    public string? Value { get; set; }
}
