using NovaTech.TerraTech.Platform.Iam.Application.QueryServices;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Queries;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.ValueObjects;
using NovaTech.TerraTech.Platform.Iam.Domain.Repository;

namespace NovaTech.TerraTech.Platform.Iam.Application.Internal.QueryServices;

/// <summary>
///     The user query service implementation class.
/// </summary>
/// <remarks>
///     This class is used handle user queries.
/// </remarks>
public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    /// <summary>
    ///     Handle get user by id.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the user id to search. 
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    ///     To cancel transaction if the user leaves the platform.
    /// </param>
    /// <returns>
    ///     The user.
    /// </returns>
    public async Task<User?> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        return await userRepository.FindByIdAsync(query.Id, cancellationToken);
    }

    /// <summary>
    ///     Handle get user by Email.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the user Email to search.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    ///     To cancel transaction if the user leaves the platform.
    /// </param>
    /// <returns>
    ///     The user.
    /// </returns>
    public async Task<User?> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        return await userRepository.FindByEmailAsync(new Email(query.Email), cancellationToken);
    }
}