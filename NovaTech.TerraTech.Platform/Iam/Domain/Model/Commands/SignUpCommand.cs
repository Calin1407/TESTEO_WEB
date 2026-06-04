namespace NovaTech.TerraTech.Platform.Iam.Domain.Model.Commands;
/// <summary>
///     The SignUp Command
/// </summary>
/// <remarks>
///     This command object includes the email and password to sign up.
/// </remarks>
public record SignUpCommand(string Email, string Password);