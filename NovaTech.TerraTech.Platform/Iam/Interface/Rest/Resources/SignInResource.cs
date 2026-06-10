namespace NovaTech.TerraTech.Platform.Iam.Interface.Rest.Resources;

/// <summary>
///     Represents the inbound credentials required for a user to sign in.
/// </summary>
public record SignInResource(string EmailAddress, string Password);