using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.StockManagement.Domain.Model.Aggregates;

namespace NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Stock bounded context model builder extensions
/// </summary>
public static class StockModelBuilderExtensions
{
    /// <summary>
    ///     Apply Inventory entity configuration
    /// </summary>
    /// <param name="builder">The model builder</param>
    public static void ApplyStockConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Inventory>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Id).ValueGeneratedOnAdd();
            
            entity.Property(i => i.ProductId)
                .IsRequired()
                .HasMaxLength(255);
                
            entity.Property(i => i.StockQuantity)
                .IsRequired();
                
            entity.Property(i => i.WarehouseLocation)
                .HasMaxLength(255);
        });
    }
}