using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("API_KEYS")]
public class ApiKey : BaseEntity
{
    [Column("KEY")]
    public string? Key { get; set; }

    [Column("NAME")]
    public string? Name { get; set; }

    [Column("USER_ID")]
    public int UserId { get; set; }

    [Column("TENANT_ID")]
    public long TenantId { get; set; }

    [Column("EXPIRES_AT")]
    public DateTime ExpiresAt { get; set; }

    [Column("REVOKED_AT")]
    public DateTime RevokedAt { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
