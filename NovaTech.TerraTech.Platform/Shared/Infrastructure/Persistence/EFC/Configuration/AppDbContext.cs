using Microsoft.EntityFrameworkCore;
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
        // TODO: Define data annotations and Fluent API configurations for bounded context entities here.
    }
}