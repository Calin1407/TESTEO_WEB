using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;

namespace NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Apply audit timestamp interceptor for all IAuditableEntity implementations
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // TODO: Define data annotations and Fluent API configurations for bounded context entities here.
        
        // Bounded Context Iam 
        builder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).ValueGeneratedOnAdd();
        
            entity.OwnsOne(u => u.EmailAddress, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName("email_address")
                    .IsRequired()
                    .HasMaxLength(255);
                email.HasIndex(e => e.Value).IsUnique();
            });

            entity.Property(u => u.PasswordHash).IsRequired();
            entity.Property(u => u.CreatedAt);
            entity.Property(u => u.UpdatedAt);
        });
    }
}