using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("USERS")]
public class User : BaseEntity
{
    [Column("FIRST_NAME")]
    public string? FirstName { get; set; }

    [Column("LAST_NAME")]
    public string? LastName { get; set; }

    [Column("EMAIL")]
    public string? Email { get; set; }

    [Column("PASSWORD")]
    public string? Password { get; set; }

    [Column("ACTIVE")]
    public bool Active { get; set; }

    [Column("LANGUAGE")]
    public string? Language { get; set; }

    [Column("TENANT_ID")]
    public long TenantId { get; set; }

    [Column("INVITE_ACCEPTED_AT")]
    public DateTime InviteAcceptedAt { get; set; }

    [Column("LAST_LOGIN_AT")]
    public DateTime LastLoginAt { get; set; }

    [Column("DELETED_AT")]
    public DateTime DeletedAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }

    [Column("VERIFY_TOKEN")]
    public string? VerifyToken { get; set; }

    [Column("VERIFIED")]
    public bool Verified { get; set; }
}
