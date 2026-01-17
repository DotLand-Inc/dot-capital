using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.System;

[Table("PASSWORD_RESETS")]
public class PasswordReset : BaseEntity
{
    [Column("EMAIL")]
    public string? Email { get; set; }

    [Column("TOKEN")]
    public string? Token { get; set; }

    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }
}
