using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Aggregates;

namespace NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Notification bounded context model builder extensions
/// </summary>
public static class NotificationModelBuilderExtensions
{
    /// <summary>
    ///     Apply Notification entity configuration
    /// </summary>
    /// <param name="builder">The model builder</param>
    public static void ApplyNotificationConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Notification>(entity =>
        {
            // No se especifica ToTable porque UseSnakeCaseNamingConvention lo hará automáticamente
            // El nombre de la tabla será "notifications" (plural y snake_case)
            
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Id).ValueGeneratedOnAdd();
            
            entity.Property(n => n.ProfileId)
                .IsRequired()
                .HasMaxLength(255);
                
            entity.Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(255);
                
            entity.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(1000);
                
            entity.Property(n => n.IsRead)
                .IsRequired();
                
            entity.Property(n => n.IsAlert)
                .IsRequired();
            
            // CreatedAt y UpdatedAt no necesitan configuración explícita
            // El interceptor AuditableEntityInterceptor los maneja automáticamente
        });
    }
}