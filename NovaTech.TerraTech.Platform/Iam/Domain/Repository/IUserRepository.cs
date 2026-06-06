using NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.ValueObjects;
using NovaTech.TerraTech.Platform.Shared.Domain.Repositories;

namespace NovaTech.TerraTech.Platform.Iam.Domain.Repository;

/// <summary>
///     The repository for User aggregate.
/// </summary>
/// <remarks>
///     This repository is used to manage users.
/// </remarks>
public interface IUserRepository : IBaseRepository<User>
{
    /// <summary>
    ///     Finds a user by their validated email address.
    /// </summary>
    /// <param name="emailAddress">
    ///     The unique email value object to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token
    /// </param>
    /// <returns>
    ///     The task results contains the User if found; in otherwise is null.
    /// </returns>
    Task<User?> FindByEmailAsync(Email emailAddress, CancellationToken cancellationToken);
    
    /// <summary>
    ///     Checks if a users Email already exists in the database.
    /// </summary>
    /// <param name="emailAddress">
    ///     The email value object to validate uniqueness against.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token
    /// </param>
    /// <returns>
    ///     True if the email is already; in otherwise is false.
    /// </returns>
    Task<bool> ExistsByEmailAsync(Email emailAddress, CancellationToken cancellationToken);
}