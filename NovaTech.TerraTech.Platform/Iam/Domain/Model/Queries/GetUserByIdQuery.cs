namespace NovaTech.TerraTech.Platform.Iam.Domain.Model.Queries;
/// <summary>
///     The get User by id
/// </summary>
/// <remarks>
///     This query object includes the user id to search
/// </remarks>
public record GetUserByIdQuery(int Id);