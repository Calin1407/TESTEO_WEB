namespace NovaTech.TerraTech.Platform.Iam.Interface.Rest.Resources;

/// <summary>
///     Represents the outbound user data sent to the client.
/// </summary>
public record UserResource(int Id, string EmailAddress);