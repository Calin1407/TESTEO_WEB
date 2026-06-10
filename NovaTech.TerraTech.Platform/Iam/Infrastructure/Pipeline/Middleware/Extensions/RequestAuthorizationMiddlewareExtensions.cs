using NovaTech.TerraTech.Platform.Iam.Infrastructure.Pipeline.Middleware.Components;

namespace NovaTech.TerraTech.Platform.Iam.Infrastructure.Pipeline.Middleware.Extensions;

/// <summary>
///     The Request Authorization Middleware Extensions.
/// </summary>
/// <remarks>
///     This class includes a method extension to register RequestAuthorizationMiddleware in the ASP.NET Core pipeline.
/// </remarks>
public static class RequestAuthorizationMiddlewareExtensions
{
    /// <summary>
    ///     UseRequestAuthorization extension method is used to register RequestAuthorizationMiddleware in the ASP.NET Core pipeline.
    /// </summary>
    public static IApplicationBuilder UserRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }    
}