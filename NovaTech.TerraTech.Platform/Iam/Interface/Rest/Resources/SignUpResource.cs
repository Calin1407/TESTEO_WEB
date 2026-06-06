namespace NovaTech.TerraTech.Platform.Iam.Interface.Rest.Resources;

/// <summary>
///     Represents the inbound data required to register a new user.
/// </summary>
public record SignUpResource(string EmailAddress, string Password);