namespace NovaTech.TerraTech.Platform.Iam.Domain.Model.Commands;
/// <summary>
///     The SignIn Command
/// </summary>
/// <remarks>
///     This command object includes the email and password to sign in.
/// </remarks>
public record SignInCommand(string Email, string Password);