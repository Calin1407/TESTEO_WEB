using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.NotificationManagement.Domain.Repositories;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaTech.TerraTech.Platform.NotificationManagement.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository(AppDbContext context) : BaseRepository<Notification>(context), INotificationRepository
{
    public async Task<IEnumerable<Notification>> FindByProfileIdAsync(string profileId, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Notification>()
            .Where(n => n.ProfileId == profileId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Notification>> FindUnreadByProfileIdAsync(string profileId, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Notification>()
            .Where(n => n.ProfileId == profileId && !n.IsRead)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}