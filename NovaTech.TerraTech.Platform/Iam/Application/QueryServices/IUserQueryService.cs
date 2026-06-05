using NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Queries;

namespace NovaTech.TerraTech.Platform.Iam.Application.QueryServices;

/// <summary>
///     The user query service interface.
/// </summary>
/// <remarks>
///     This service contract specifies handling behavior used to query users.
///     Inbound Port to allow queries interaction with the user.
/// </remarks>
public interface IUserQueryService
{
    /// <summary>
    ///     Handle get user by id.
    /// </summary>
    /// <param name="query">
    ///     The get user by id query.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     The user if found, in otherwise is null.
    /// </returns>
    Task<User?> Handle(GetUserByIdQuery query, CancellationToken cancellationToken);
    
    /// <summary>
    ///     Handle get user by Email.
    /// </summary>
    /// <param name="query">
    ///     The get user by Email query.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     The user if found, in otherwise is null.
    /// </returns>
    Task<User?> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken);
}