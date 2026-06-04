using System.Text.Json.Serialization;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.ValueObjects;

namespace NovaTech.TerraTech.Platform.Iam.Domain.Model.Aggregates;

///<summary>
///       The user aggregate.
/// </summary>
/// <remarks>
///      This class is used to represent a user.
/// </remarks>
public partial class User(Email email, Password password)
{
    public User() : this(null!, null!)
    {
    }
    
    public int Id { get; }
    public Email Email { get; private set; } = email;
    
    [JsonIgnore]
    public Password Password { get; private set; } = password;
}