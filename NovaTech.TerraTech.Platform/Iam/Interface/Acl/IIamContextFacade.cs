namespace NovaTech.TerraTech.Platform.Iam.Interface.Acl;

/// <summary>
///     The Iam context Facade.
/// </summary>
/// <remarks>
///     This interface as the public entry point for external modules.
/// </remarks>
public interface IIamContextFacade
{
    /// <summary>
    ///     Creates a new user account from an external context request. 
    /// </summary>
    /// <param name="email">
    ///     The user email.
    /// </param>
    /// <param name="password">
    ///     The user password.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    ///     To cancel transaction if the user leaves the platform.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    /// </returns>
    Task<int> CreateUser(string email, string password, CancellationToken cancellationToken);
    
    /// <summary>
    ///     Fetches the unique user identifier associated with a given email address.
    /// </summary>
    /// <param name="email">
    ///     The user email.
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    ///     To cancel transaction if the user leaves the platform.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    /// </returns>
    Task<int> FetchUserByEmail(string email, CancellationToken cancellationToken);
    
    /// <summary>
    ///     
    /// </summary>
    /// <param name="usedId">
    ///     
    /// </param>
    /// <param name="cancellationToken">
    ///     The cancellation token.
    ///     To cancel transaction if the user leaves the platform.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    /// </returns>
    Task<string> FetchEmailByUserId(int usedId, CancellationToken cancellationToken);
}