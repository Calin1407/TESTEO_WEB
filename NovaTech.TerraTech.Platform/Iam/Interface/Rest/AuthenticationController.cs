using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NovaTech.TerraTech.Platform.Iam.Application.CommandServices;
using NovaTech.TerraTech.Platform.Iam.Infrastructure.Pipeline.Middleware.Attributes;
using NovaTech.TerraTech.Platform.Iam.Interface.Rest.Resources;
using NovaTech.TerraTech.Platform.Iam.Interface.Rest.Transform;
using NovaTech.TerraTech.Platform.Iam.Resources;
using NovaTech.TerraTech.Platform.Shared.Interfaces.Rest.ProblemDetails;
using NovaTech.TerraTech.Platform.Shared.Resources.Errors;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaTech.TerraTech.Platform.Iam.Interface.Rest;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Authentication endpoints")]
public class AuthenticationController(
    IUserCommandService userCommandService, IStringLocalizer<ErrorMessages> errorLocalizer,
    IStringLocalizer<IamMessages> iamLocalizer, ProblemDetailsFactory problemDetailsFactory) 
    : ControllerBase
{
    [HttpPost("sign-in")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Sign in",
        Description = "Sign in a User",
        OperationId = "SignIn")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user was authenticated", typeof(AuthenticatedUserResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid email or password")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource signInResource,
        CancellationToken cancellationToken)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(signInResource);
        var result = await userCommandService.Handle(signInCommand, cancellationToken);

        return IamActionResultAssembler.ToActionResultFromSignInResult(
            this,
            result,
            errorLocalizer,
            problemDetailsFactory,
            userAndToken =>
                Ok(AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(userAndToken.user,
                    userAndToken.token))
        );
    }

    [HttpPost("sign-up")]
    [AllowAnonymous]
    [SwaggerOperation(
        Summary = "Sign up",
        Description = "Sign up a new User",
        OperationId = "SignUp")]
    [SwaggerResponse(StatusCodes.Status200OK, "The user was authenticated")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The user was not created")]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource signUpResource,
        CancellationToken cancellationToken)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);
        var result = await userCommandService.Handle(signUpCommand, cancellationToken);

        return IamActionResultAssembler.ToActionResultFromSignUpResult(
            this,
            result,
            errorLocalizer,
            problemDetailsFactory,
            () => Ok(new { message = iamLocalizer["UserCreatedSuccessfully"] })
        );
    }
}