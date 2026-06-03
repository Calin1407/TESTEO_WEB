using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Aggregates;

namespace NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Notification> Notifications { get; set; }
    
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
        
        builder.Entity<Notification>(entity =>
        {
            entity.ToTable("notifications");
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Id).ValueGeneratedOnAdd();
            entity.Property(n => n.ProfileId).IsRequired().HasMaxLength(255);
            entity.Property(n => n.Title).IsRequired().HasMaxLength(255);
            entity.Property(n => n.Message).IsRequired().HasMaxLength(1000);
            entity.Property(n => n.IsRead).IsRequired();
            entity.Property(n => n.IsAlert).IsRequired();
            entity.Property(n => n.CreatedAt);
            entity.Property(n => n.UpdatedAt);
        });
    }
}