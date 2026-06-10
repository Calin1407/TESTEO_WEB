using NovaTech.TerraTech.Platform.Iam.Application.CommandServices;
using NovaTech.TerraTech.Platform.Iam.Application.QueryServices;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Commands;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Queries;
using NovaTech.TerraTech.Platform.Iam.Interface.Acl;

namespace NovaTech.TerraTech.Platform.Iam.Application.Acl;

/// <summary>
///     The Facade for the IAM Context.
/// </summary>
/// <param name="userCommandService">
///     The user command service.
/// </param>
/// <param name="userQueryService">
///     The user query service.
/// </param>
/// <remarks>
///     This is a Facade implementation to Iam Context Anti-Corruption Layer
///     to communicate to others Context (ex. Profile).
/// </remarks>
public class IamContextFacade(IUserCommandService userCommandService
    , IUserQueryService userQueryService): IIamContextFacade
{
    /// <summary>
    ///     Create user task.
    /// </summary>
    /// <param name="email">
    ///     The user email.
    /// </param>
    /// <param name="password">
    ///     The user password.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     If is successful return user id, in otherwise false.
    /// </returns>
    public async Task<int> CreateUser(string email, string password, CancellationToken cancellationToken)
    {
        var signUpCommand = new SignUpCommand(email, password);
        var signUpResult = await userCommandService.Handle(signUpCommand, cancellationToken);

        if (signUpResult.IsFailure) return 0;
        
        var getUserByEmailQuery = new GetUserByEmailQuery(email);
        var result = await userQueryService.Handle(getUserByEmailQuery, cancellationToken);

        return result?.Id ?? 0;
    }

    /// <summary>
    ///     Search user by email.
    /// </summary>
    /// <param name="email">
    ///     The user email.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     If is successful return user id, in otherwise is false.
    /// </returns>
    public async Task<int> FetchUserByEmail(string email, CancellationToken cancellationToken)
    {
        var getUserByEmailQuery = new GetUserByEmailQuery(email);
        var result = await userQueryService.Handle(getUserByEmailQuery, cancellationToken);
        
        return result?.Id ?? 0;
    }

    /// <summary>
    ///     Search user email by user id.
    /// </summary>
    /// <param name="userId">
    ///     The user id.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    /// </param>
    /// <returns>
    ///     If is successful return user email, in otherwise is empty.
    /// </returns>
    public async Task<string> FetchEmailByUserId(int userId, CancellationToken cancellationToken)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery, cancellationToken);
        
        return result?.EmailAddress.Value ?? string.Empty;
    }
}