namespace NovaTech.TerraTech.Platform.Iam.Interface.Rest.Resources;

/// <summary>
///     The output after login
/// </summary>
public record AuthenticatedUserResource(int Id, string EmailAddress, string Token);