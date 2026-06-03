using NovaTech.TerraTech.Platform.Shared.Domain.Model;

namespace NovaTech.TerraTech.Platform.ProfileManagement.Domain.Model.Aggregates;

/// <summary>
///     Audit extension for Profile aggregate.
/// </summary>
/// <remarks>
///     This partial class extends Profile with audit trail properties.
///     CreatedAt and UpdatedAt are automatically managed by the persistence layer
///     via the AuditableEntityInterceptor in the Shared bounded context.
///     Implements the IAuditableEntity interface to provide these properties.
/// </remarks>
public partial class Profile : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    
    public DateTimeOffset? UpdatedAt { get; set; }
}