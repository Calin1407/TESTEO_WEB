using NovaTech.TerraTech.Platform.Iam.application.Internal.OutboundServices;
using NovaTech.TerraTech.Platform.Iam.Application.QueryServices;
using NovaTech.TerraTech.Platform.Iam.Domain.Model.Queries;
using NovaTech.TerraTech.Platform.Iam.Infrastructure.Pipeline.Middleware.Attributes;

namespace NovaTech.TerraTech.Platform.Iam.Infrastructure.Pipeline.Middleware.Components;

/// <summary>
///     RequestAuthorizationMiddleware is a custom middleware.
///     This middleware is used to authorize requests.
///     It validates a token is included in the request header and that the token is valid.
///     If the token is valid then it sets the user in HttpContext.Items["User"].
/// </summary>
public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    /// <summary>
    ///     InvokeAsync is called by the ASP.NET Core runtime.
    ///     It is used to authorize requests.
    ///     It validates a token is included in the request header and that the token is valid.
    ///     If the token is valid then it sets the user in HttpContext.Items["User"].
    /// </summary>
    public async Task InvokeAsync(HttpContext context, IUserQueryService userQueryService
        , ITokenService tokenService, CancellationToken cancellationToken)
    {
        Console.WriteLine("Entering InvokeAsync");
        var allowAnonymous = context.Request.HttpContext.GetEndpoint()!.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute));
        Console.WriteLine($"Allow Anonymous is {allowAnonymous}");

        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            await next(context);
            return;
        }
        
        Console.WriteLine("Entering authorization");
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        
        if (token == null) throw new Exception("Null or Invalid token");
        
        var userId = await tokenService.ValidateToken(token);
        
        if (userId == null) throw new Exception("Invalid token");
        
        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);
        
        var user = await userQueryService.Handle(getUserByIdQuery, cancellationToken);
        Console.WriteLine("Successful authorization. Updating Context...");
        context.Items["User"] = user;
        Console.WriteLine("Continuing with Middleware Pipeline");
        
        await next(context);
    }
}