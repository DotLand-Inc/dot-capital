using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("USER_INVITES")]
public class UserInvite : BaseEntity
{
    [Column("EMAIL")]
    public string? Email { get; set; }

    [Column("TOKEN")]
    public string? Token { get; set; }

    [Column("TENANT_ID")]
    public long TenantId { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }
}
