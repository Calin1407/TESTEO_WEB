using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.ValueObjects;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Repositories;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NovaTech.TerraTech.Platform.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class FieldRepository(AppDbContext context) : BaseRepository<Field>(context), IFieldRepository
{
    public async Task<IEnumerable<Field>> FindBySoilTypeAsync(SoilType SoilType,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<Field>()
            .Where(f => f.SoilType.Value == SoilType.Value)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Field?> FindBySoilTypeAndLocationLatLongAsync(SoilType SoilType, LocationLatLong LocationLatLong,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<Field>()
            .FirstOrDefaultAsync(f => f.SoilType.Value == SoilType.Value 
                && f.LocationLatLong.Latitude == LocationLatLong.Latitude 
                && f.LocationLatLong.Longitude == LocationLatLong.Longitude,
                cancellationToken);
    }
}