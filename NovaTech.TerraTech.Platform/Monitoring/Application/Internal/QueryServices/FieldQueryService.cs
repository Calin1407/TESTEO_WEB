using NovaTech.TerraTech.Platform.Monitoring.Application.Services;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Monitoring.Domain.Repositories;

namespace NovaTech.TerraTech.Platform.Monitoring.Application.Internal.QueryServices;

/// <summary>
/// Implementation of IFieldQueryService for querying Field aggregates.
/// </summary>
public class FieldQueryService(IFieldRepository fieldRepository) 
    : IFieldQueryService
{
    /// <inheritdoc />
    public async Task<Field?> GetFieldByIdAsync(int fieldId, CancellationToken cancellationToken = default) =>
        await fieldRepository.FindByIdAsync(fieldId, cancellationToken);

    /// <inheritdoc />
    public async Task<IEnumerable<Field>> GetAllFieldsAsync(CancellationToken cancellationToken = default) =>
        await fieldRepository.ListAsync(cancellationToken);
}