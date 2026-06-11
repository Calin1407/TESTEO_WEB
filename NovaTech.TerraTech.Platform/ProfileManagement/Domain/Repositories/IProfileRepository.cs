using NovaTech.TerraTech.Platform.ProfileManagement.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Shared.Domain.Repositories;

namespace NovaTech.TerraTech.Platform.ProfileManagement.Domain.Repositories;

/// <summary>
///     Profile repository interface
/// </summary>
public interface IProfileRepository : IBaseRepository<Profile>
{
    
    // Task<Profile?> FindProfileByUserIdAsync(string userId);
}