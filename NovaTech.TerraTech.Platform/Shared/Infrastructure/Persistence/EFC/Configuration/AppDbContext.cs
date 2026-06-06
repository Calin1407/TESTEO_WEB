using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.ProfileManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.StockManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;

namespace NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Notification> Notifications { get; set; }
    // public DbSet<Profile> Profiles { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    
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

        // Notification Management Context
        builder.ApplyNotificationConfiguration();
        
        // Stock Management Context
        builder.ApplyStockConfiguration();

        // Profile Management Context (cuando lo tengas)
        // builder.ApplyProfileConfiguration();

        // Monitoring Context (cuando lo tengas)
        // builder.ApplyMonitoringConfiguration();

        // General Naming Convention for the database objects
        builder.UseSnakeCaseNamingConvention();
    }
}