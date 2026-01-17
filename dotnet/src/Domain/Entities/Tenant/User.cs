using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("USERS")]
public class User : BaseEntity
{
    [Column("FIRST_NAME")]
    public string? FirstName { get; set; }

    [Column("LAST_NAME")]
    public string? LastName { get; set; }

    [Column("EMAIL")]
    public string? Email { get; set; }

    [Column("ACTIVE")]
    public bool Active { get; set; }

    [Column("ROLE_ID")]
    public int RoleId { get; set; }

    [Column("SYSTEM_USER_ID")]
    public int SystemUserId { get; set; }

    [Column("INVITED_AT")]
    public DateTime InvitedAt { get; set; }

    [Column("INVITE_ACCEPTED_AT")]
    public DateTime InviteAcceptedAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
