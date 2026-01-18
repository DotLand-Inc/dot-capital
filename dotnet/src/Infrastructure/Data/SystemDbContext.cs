using System.Reflection;
using Dotland.DotCapital.WebApi.Application.Common.Interfaces;
using Dotland.DotCapital.WebApi.Domain.Entities.System;
using Dotland.DotCapital.WebApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dotland.DotCapital.WebApi.Infrastructure.Data;

public class SystemDbContext(DbContextOptions<SystemDbContext> options)
    : IdentityDbContext<ApplicationUser>(options), ISystemDbContext
{
    public DbSet<TenantEntity> Tenants => Set<TenantEntity>();
    public DbSet<Domain.Entities.System.TenantsMetadata> TenantsMetadatas => Set<Domain.Entities.System.TenantsMetadata>();
    public DbSet<Domain.Entities.System.SubscriptionPlan> SubscriptionPlans => Set<Domain.Entities.System.SubscriptionPlan>();
    public DbSet<Domain.Entities.System.UserInvite> UserInvites => Set<Domain.Entities.System.UserInvite>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Map Identity tables to lowercase names to match existing MySQL schema
        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("users");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserName).HasColumnName("username");
            entity.Property(e => e.NormalizedUserName).HasColumnName("normalized_username");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.NormalizedEmail).HasColumnName("normalized_email");
            entity.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");
            entity.Property(e => e.PasswordHash).HasColumnName("password"); // Maps 'PasswordHash' to 'password' column
            entity.Property(e => e.SecurityStamp).HasColumnName("security_stamp");
            entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
            entity.Property(e => e.TwoFactorEnabled).HasColumnName("two_factor_enabled");
            entity.Property(e => e.LockoutEnd).HasColumnName("lockout_end");
            entity.Property(e => e.LockoutEnabled).HasColumnName("lockout_enabled");
            entity.Property(e => e.AccessFailedCount).HasColumnName("access_failed_count");
        });

        builder.Entity<IdentityRole>(entity => entity.ToTable("roles"));
        builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable("user_roles"));
        builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable("user_claims"));
        builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable("user_logins"));
        builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("role_claims"));
        builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable("user_tokens"));
    }
}
