using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NovaTech.TerraTech.Platform.Monitoring.Application.Services;
using NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST.Resources;
using NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST.Transform;
using NovaTech.TerraTech.Platform.Shared.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaTech.TerraTech.Platform.Monitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Field")]
public class FieldController(
    IFieldCommandService fieldCommandService,
    IFieldQueryService fieldQueryService,
    IStringLocalizer<CommonMessages> localizer,
    ILogger<FieldController> logger)
    : ControllerBase
{
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a Field",
        Description = "Creates a Field with a given Soil Type and Location",
        OperationId = "CreateField")]
    [SwaggerResponse(201, "The Field was created", typeof(FieldResource))]
    [SwaggerResponse(400, "The request payload is invalid", typeof(string))]
    [SwaggerResponse(409, "The Field already exists", typeof(string))]
    [SwaggerResponse(500, "Unexpected server error", typeof(ProblemDetails))]
    public async Task<ActionResult> CreateField([FromBody] CreateFieldResource resource,
        CancellationToken cancellationToken)
    {
        try
        {
            var createFieldCommand =
                CreateFieldCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await fieldCommandService.Handle(createFieldCommand, cancellationToken);
            return ActionResultFromCreateFieldResultAssembler.ToActionResultFromCreateFieldResult(
                result,
                this,
                localizer,
                nameof(GetFieldById));
        }
        catch (ArgumentException ex)
        {
            logger.LogWarning(ex,
                "Validation failed while creating Field for SoilType {SoilType}",
                resource.SoilType);
            return BadRequest(localizer["InvalidFieldRequest"].Value);
        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                "Unexpected error while creating field for SoilType {SoilType}",
                resource.SoilType);

            return Problem(
                title: localizer["UnexpectedServerError"].Value,
                detail: localizer["UnexpectedErrorCreatingField"].Value,
                statusCode: 500);
        }
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all fields",
        Description = "Retrieves all available fields",
        OperationId = "GetAllFields")]
    [SwaggerResponse(200, "List of all fields", typeof(IEnumerable<FieldResource>))]
    public async Task<ActionResult<IEnumerable<FieldResource>>> GetAllFields(CancellationToken cancellationToken)
    {
        try
        {
            var fields = await fieldQueryService.GetAllFieldsAsync(cancellationToken);
            var resources = fields.Select(FieldResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error while retrieving all fields");
            return Problem(
                title: localizer["UnexpectedServerError"].Value,
                detail: localizer["UnexpectedErrorProcessingRequest"].Value,
                statusCode: 500);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets a field by id",
        Description = "Retrieves a specific field by its identifier",
        OperationId = "GetFieldById")]
    [SwaggerResponse(200, "The field was found", typeof(FieldResource))]
    [SwaggerResponse(404, "The field was not found")]
    public async Task<ActionResult> GetFieldById(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var field = await fieldQueryService.GetFieldByIdAsync(id, cancellationToken);
            if (field is null) return NotFound();
            var resource = FieldResourceFromEntityAssembler.ToResourceFromEntity(field);
            return Ok(resource);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error while retrieving field with id {FieldId}", id);
            return Problem(
                title: localizer["UnexpectedServerError"].Value,
                detail: localizer["UnexpectedErrorProcessingRequest"].Value,
                statusCode: 500);
        }
    }
    
}