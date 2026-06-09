using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.ValueObjects;

namespace NovaTech.TerraTech.Platform.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMonitoringConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Field>(field =>
        {
            field.HasKey(f => f.Id);
            field.Property(f => f.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            field.OwnsOne(f => f.LocationLatLong, loc =>
            {
                loc.WithOwner().HasForeignKey("Id");
                
                loc.Property(l => l.Latitude)
                    .HasColumnName("Latitude")
                    .IsRequired();
                    
                loc.Property(l => l.Longitude)
                    .HasColumnName("Longitude")
                    .IsRequired();
            });

            field.OwnsOne(f => f.SoilType, soil =>
            {
                soil.WithOwner().HasForeignKey("Id");
                
                soil.Property(s => s.Value)
                    .HasColumnName("SoilType")
                    .HasMaxLength(50)
                    .IsRequired();
            });
        });
    }
}