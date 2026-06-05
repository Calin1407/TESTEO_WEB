using NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Commands;
using NovaTech.TerraTech.Platform.Shared.Application.Model;

namespace NovaTech.TerraTech.Platform.Iam.application.CommandServices;

/// <summary>
///     The user command service.
/// </summary>
/// <remarks>
///     This interface is used to handle user commands.
///     Inbound Port to allow commands interaction with the user.
/// </remarks>
public interface IUserCommandService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result<(User user, string token)>> Handle(SignInCommand command, CancellationToken cancellationToken);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result> Handle(SignUpCommand command, CancellationToken cancellationToken);
}