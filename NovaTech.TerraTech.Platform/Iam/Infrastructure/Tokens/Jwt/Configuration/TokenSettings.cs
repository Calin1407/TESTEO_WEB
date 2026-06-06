namespace NovaTech.TerraTech.Platform.Iam.Infrastructure.Tokens.Jwt.Configuration;

/// <summary>
///     The token settings
/// </summary>
/// <remarks>
///     This class is used to store the token settings.
///     It is used to configure the token settings in the app settings .json file.
/// </remarks>
public class TokenSettings
{
    public required string Secret { get; set; }
}