using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Dotland.DotCapital.WebApi.Infrastructure.Identity;

[Table("users")]
public class ApplicationUser : IdentityUser
{
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")]
    public string LastName { get; set; } = string.Empty;

    [Column("tenant_id")]
    public int? TenantId { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [Column("invite_accepted_at")]
    public DateTime? InviteAcceptedAt { get; set; }
}
