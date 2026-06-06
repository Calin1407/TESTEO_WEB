using NovaTech.TerraTech.Platform.Iam.application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace NovaTech.TerraTech.Platform.Iam.Infrastructure.Hashing.BCrypt.Services;

/// <summary>
///     Implements Hashing service.
/// </summary>
/// <remarks>
///     This class is responsible for hashing and validation passwords.
/// </remarks>
public class HashingService: IHashingService
{
    /// <summary>
    ///     This method hashes a password.
    /// </summary>
    /// <param name="password">
    ///     The password to passwordHash.
    /// </param>
    /// <returns>
    ///     The hashed password.
    /// </returns>
    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);
    }

    /// <summary>
    ///     This method validates a password against a passwordHash.
    /// </summary>
    /// <param name="password">
    ///     The password to validate.
    /// </param>
    /// <param name="hashedPassword">
    ///     The passwordHash to validate against.
    /// </param>
    /// <returns>
    ///     True if the password is valid, otherwise is false.
    /// </returns>
    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCryptNet.Verify(password, hashedPassword);
    }
}