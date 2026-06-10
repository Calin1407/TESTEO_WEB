using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Aggregates;

namespace NovaTech.TerraTech.Platform.Monitoring.Application.Services;

/// <summary>
/// Service interface for querying Field aggregates.
/// </summary>
public interface IFieldQueryService
{
    /// <summary>
    /// Gets a field by its ID.
    /// </summary>
    /// <param name="fieldId">The field ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The field if found, otherwise null.</returns>
    Task<Field?> GetFieldByIdAsync(int fieldId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all fields.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of all fields.</returns>
    Task<IEnumerable<Field>> GetAllFieldsAsync(CancellationToken cancellationToken = default);
}