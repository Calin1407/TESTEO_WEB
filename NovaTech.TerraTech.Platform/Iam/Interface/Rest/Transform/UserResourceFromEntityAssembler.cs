using NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;
using NovaTech.TerraTech.Platform.Iam.Interface.Rest.Resources;

namespace NovaTech.TerraTech.Platform.Iam.Interface.Rest.Transform;

/// <summary>
///     Assembler responsible for transforming a <see cref="User"/> aggregate into <see cref="UserResource"/>.
/// </summary>
public static class UserResourceFromEntityAssembler
{
    /// <summary>
    ///     Converts a <see cref="User"/> aggregate to its <see cref="UserResource"/> representation.
    /// </summary>
    /// <param name="user">
    ///     The <see cref="User"/> aggregate to convert. Must be not null.
    /// </param>
    /// <returns>
    ///     A new <see cref="UserResource"/> instance.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if the input <paramref name="user"/> is null.
    /// </exception>
    public static UserResource ToResourceFromEntity(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User aggregate cannot be null when converting to resource.");
        }
        return new UserResource(user.Id, user.EmailAddress.Value);
    }
}