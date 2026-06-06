using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using NovaTech.TerraTech.Platform.StockManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.StockManagement.Domain.Repositories;

namespace NovaTech.TerraTech.Platform.StockManagement.Infrastructure.Persistence.EFC.Repositories;

public class InventoryRepository(AppDbContext context) : BaseRepository<Inventory>(context), IInventoryRepository
{
    public async Task<Inventory?> FindByProductIdAsync(string productId, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Inventory>()
            .FirstOrDefaultAsync(i => i.ProductId == productId, cancellationToken);
    }
}