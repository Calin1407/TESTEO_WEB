namespace NovaTech.TerraTech.Platform.Iam.Domain.Model.Queries;
/// <summary>
///     The get User by Email Address
/// </summary>
/// <remarks>
///     This query object includes the user Email to search
/// </remarks>
public record GetUserByEmailQuery(string Email);