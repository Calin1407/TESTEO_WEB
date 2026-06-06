using Microsoft.EntityFrameworkCore;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.ValueObjects;
using NovaTech.TerraTech.Platform.Iam.Domain.Repository;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaTech.TerraTech.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaTech.TerraTech.Platform.Iam.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

/// <summary>
///     The user repository.
/// </summary>
/// <remarks>
///     This repository is used to manage users.
/// </remarks>
public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    /// <summary>
    ///     Find a user by Email.
    /// </summary>
    /// <param name="email">
    ///     The email to search.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     The user.
    /// </returns>
    public async Task<User?> FindByEmailAsync(Email email, CancellationToken cancellationToken)
    {
        return await Context.Set<User>()
            .FirstOrDefaultAsync(user => user.EmailAddress.Value == email.Value, cancellationToken);
    }

    /// <summary>
    ///     Check if user exits by Email.
    /// </summary>
    /// <param name="email">
    ///     The Email to search.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     True if the user exists, in otherwise is false.
    /// </returns>
    public async Task<bool> ExistsByEmailAsync(Email email, CancellationToken cancellationToken)
    {
        return await Context.Set<User>()
            .AnyAsync(user => user.EmailAddress.Value == email.Value, cancellationToken);
    }
}