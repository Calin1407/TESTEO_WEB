using System.Text.Json.Serialization;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.ValueObjects;

namespace NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;

///<summary>
///       The user aggregate.
/// </summary>
/// <remarks>
///      This class is used to represent a user.
/// </remarks>
public partial class User(Email emailAddress, string passwordHash)
{
    public User() : this(null!, string.Empty)
    {
    }
    
    public int Id { get; }
    public Email EmailAddress { get; private set; } = emailAddress;
    
    [JsonIgnore]
    public string PasswordHash { get; private set; } = passwordHash;

    public User UpdateEmail(Email newEmail)
    {
        EmailAddress = newEmail;
        return this;
    }

    public User UpdatePasswordHash(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        return this;
    }
}