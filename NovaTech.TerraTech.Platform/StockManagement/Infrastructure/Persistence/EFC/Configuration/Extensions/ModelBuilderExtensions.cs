using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.StockManagement.Domain.Model.Aggregates;

namespace NovaTech.TerraTech.Platform.StockManagement.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyStockConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Inventory>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

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